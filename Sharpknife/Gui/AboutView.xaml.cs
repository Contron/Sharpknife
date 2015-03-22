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
	public partial class AboutView : Window
	{
		/// <summary>
		/// Creates a new about window.
		/// </summary>
		public AboutView()
		{
			this.InitializeComponent();
		}
	}
}
