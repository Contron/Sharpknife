using Sharpknife.Common;
using Sharpknife.Gui.Bases;
using Sharpknife.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sharpknife.Gui
{
	/// <summary>
	/// Represents an interactive help form to show information in a structured way to the user.
	/// </summary>
	public partial class HelpForm : BaseForm
	{
		/// <summary>
		/// Shows a modal help form with the specified help articles.
		/// </summary>
		/// <param name="owner">the owner</param>
		/// <param name="helpArticles">the help articles</param>
		public static void Show(Form owner, List<HelpArticle> helpArticles)
		{
			//show
			var form = new HelpForm(helpArticles);
			form.ShowDialog(owner);
		}

		/// <summary>
		/// Creates a new help form.
		/// </summary>
		/// <param name="helpArticles">the help articles</param>
		public HelpForm(List<HelpArticle> helpArticles)
		{
			this.helpArticles = helpArticles;
			this.imageList = new ImageList();

			this.InitializeComponent();
			this.BuildHelp();
		}

		/// <summary>
		/// Builds the help.
		/// </summary>
		private void BuildHelp()
		{
			//images
			this.imageList.Images.Add(Resources.Folder);
			this.imageList.Images.Add(Resources.Article);

			//build
			var rootNode = new TreeNode("Help");
			this.BuildTree(rootNode, this.helpArticles);

			//add
			this.articlesTreeView.ImageList = this.imageList;
			this.articlesTreeView.Nodes.Add(rootNode);
			this.articlesTreeView.ExpandAll();
		}

		/// <summary>
		/// Builds a tree node.
		/// </summary>
		/// <param name="rootNode">the root node</param>
		/// <param name="helpArticles">the help articles</param>
		private void BuildTree(TreeNode rootNode, List<HelpArticle> helpArticles)
		{
			foreach (var helpArticle in helpArticles)
			{
				//image index
				var imageIndex = (helpArticle.Children.Count > 0 ? 0 : 1);

				//node
				var treeNode = new TreeNode()
				{
					Text = helpArticle.Name,
					Tag = helpArticle,
					ImageIndex = imageIndex,
					SelectedImageIndex = imageIndex
				};
				rootNode.Nodes.Add(treeNode);

				if (helpArticle.Children.Count > 0)
				{
					//children
					this.BuildTree(treeNode, helpArticle.Children);
				}
			}
		}

		/// <summary>
		/// Swaps to help for the appropriate node.
		/// </summary>
		/// <param name="treeNode">the tree node</param>
		private void SwapHelp(TreeNode treeNode)
		{
			//tag
			var tag = treeNode.Tag;

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
				this.articleTextBox.Text = "Welcome to the interactive help explorer. To get started, select an article on the left.";
			}
		}

		#region Event Handlers

		private void SwapHelpHandler(object sender, TreeViewEventArgs eventArgs)
		{
			this.SwapHelp(eventArgs.Node);
		}

		#endregion

		private List<HelpArticle> helpArticles;
		private ImageList imageList;
	}
}
