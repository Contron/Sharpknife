using Sharpknife.Desktop.Core;

namespace Sharpknife.Desktop.ViewModels
{
	class MessageViewModel : Observable
	{
		public MessageViewModel()
		{
			this.Title = "Title";
			this.Message = "Message";
		}

		public string Title
		{
			get => this.title;
			set => this.Set(ref this.title, value);
		}

		public string Message
		{
			get => this.message;
			set => this.Set(ref this.message, value);
		}

		public Command CloseCommand => Command.Close;

		private string title;
		private string message;
	}
}
