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
			get => (string) this.Get();
			set => this.Set(value);
		}

		public string Message
		{
			get => (string) this.Get();
			set => this.Set(value);
		}

		public Command CloseCommand => Command.Close;
	}
}
