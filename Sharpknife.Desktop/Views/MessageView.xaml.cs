using System.Media;
using System.Windows;
using Sharpknife.Desktop.Services;

namespace Sharpknife.Desktop.Views
{
	/// <summary>
	/// Represents a message window to display information.
	/// </summary>
	public partial class MessageView : Window
	{
		/// <summary>
		/// Creates a new message view.
		/// </summary>
		public MessageView()
		{
			this.InitializeComponent();
		}

		private void WindowLoaded(object sender, RoutedEventArgs args)
		{
			SoundService.Instance.PlaySystem(SystemSounds.Beep);
		}
	}
}
