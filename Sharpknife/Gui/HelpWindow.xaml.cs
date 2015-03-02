using Sharpknife.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sharpknife.Gui
{
	/// <summary>
	/// Represents a help window to display help articles to the user.
	/// </summary>
	public partial class HelpWindow : Window
	{
		/// <summary>
		/// Shows a modal help window with the specified help articles.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="helpArticles">the help articles</param>
		public static void Show(Window owner, List<HelpArticle> helpArticles)
		{
			//show
			var window = new HelpWindow(helpArticles)
			{
				Owner = owner
			};
			window.ShowDialog();
		}

		/// <summary>
		/// Shows a modal help window with the specified help articles.
		/// This is supposed to be used with the FindResource method of the <see cref="Control" /> class.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="helpArticles">the help articles</param>
		public static void Show(Window owner, object helpArticles)
		{
			if (helpArticles is HelpArticle[])
			{
				//show
				HelpWindow.Show(owner, ((HelpArticle[]) helpArticles).ToList());
			}
		}

		/// <summary>
		/// Creates a new help window.
		/// </summary>
		/// <param name="helpArticles">the help articles</param>
		public HelpWindow(List<HelpArticle> helpArticles)
		{
			this.helpArticles = helpArticles;

			this.InitializeComponent();
			this.BuildHelp();
		}

		/// <summary>
		/// Builds the help tree hierarchy.
		/// </summary>
		private void BuildHelp()
		{
			//root
			var treeViewItem = new TreeViewItem()
			{
				Header = "Help",
				IsExpanded = true
			};
			this.BuildNodes(treeViewItem, this.helpArticles);

			//add
			this.articlesTreeView.Items.Clear();
			this.articlesTreeView.Items.Add(treeViewItem);
		}

		/// <summary>
		/// Builds the nodes for the specified help articles.
		/// </summary>
		/// <param name="rootTreeViewItem">the root tree view item</param>
		/// <param name="helpArticles">the help articles</param>
		private void BuildNodes(TreeViewItem rootTreeViewItem, List<HelpArticle> helpArticles)
		{
			foreach (var helpArticle in helpArticles)
			{
				//node
				var treeViewItem = new TreeViewItem()
				{
					Header = helpArticle.Name,
					Tag = helpArticle,
					IsExpanded = true
				};

				//add
				rootTreeViewItem.Items.Add(treeViewItem);

				if (helpArticle.Children.Count > 0)
				{
					//children
					this.BuildNodes(treeViewItem, helpArticle.Children);
				}
			}
		}

		private void SwapHelp(TreeViewItem treeViewItem)
		{
			//tag
			var tag = treeViewItem.Tag;

			if (tag is HelpArticle)
			{
				//article
				var article = (HelpArticle) tag;
				var text = article.Text;

				//update
				this.articleTextBox.Text = text;
			}
			else
			{
				//default
				this.articleTextBox.Text = "Select an appropriate help article to view its contents.";
			}
		}

		#region Event Handlers

		private void SwapHelpHandler(object sender, RoutedPropertyChangedEventArgs<object> eventArgs)
		{
			this.SwapHelp((TreeViewItem) eventArgs.NewValue);
		}

		private void OKHandler(object sender, RoutedEventArgs eventArgs)
		{
			this.Close();
		}

		#endregion

		private List<HelpArticle> helpArticles;
	}
}
