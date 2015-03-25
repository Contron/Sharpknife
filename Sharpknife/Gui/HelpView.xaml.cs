using Sharpknife.Common;
using Sharpknife.Gui.ViewModels;
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
	/// Represents a help window to display help to the user.
	/// </summary>
	public partial class HelpView : Window
	{
		/// <summary>
		/// Creates a new help view.
		/// </summary>
		/// <param name="helpArticles">the articles</param>
		public HelpView(List<HelpArticle> helpArticles)
		{
			this.DataContext = new HelpViewModel(helpArticles);

			this.InitializeComponent();
		}
	}
}
