using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
	/// Represents an about window to display information about the application to the user.
	/// </summary>
	public partial class AboutWindow : Window
	{
		/// <summary>
		/// Shows a modal about window.
		/// </summary>
		/// <param name="owner">the owner</param>
		public static void Show(Window owner)
		{
			//show
			var window = new AboutWindow()
			{
				Owner = owner
			};
			window.ShowDialog();
		}

		/// <summary>
		/// Creates a new about window.
		/// </summary>
		public AboutWindow()
		{
			this.InitializeComponent();
			this.PopulateInformation();
		}

		/// <summary>
		/// Populates the information.
		/// </summary>
		private void PopulateInformation()
		{
			//version info
			var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

			//labels
			this.titleLabel.Text = versionInfo.ProductName;
			this.versionLabel.Text = string.Format("Version {0}", versionInfo.FileVersion);
			this.copyrightLabel.Text = string.Format("Copyright {0}", versionInfo.LegalCopyright);
		}

		#region Event Handlers

		private void OKHandler(object sender, RoutedEventArgs eventArgs)
		{
			this.Close();
		}

		#endregion
	}
}
