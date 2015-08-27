using Sharpknife.Desktop.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.ViewModels
{
	class MessageViewModel : Observable
	{
		public MessageViewModel(string title, string message)
		{
			this.Title = title;
			this.Message = message;
		}

		public MessageViewModel() : this("Title", "Message")
		{

		}

		public string Title
		{
			get
			{
				return (string) this.Get();
			}
			set
			{
				this.Set(value);
			}
		}

		public string Message
		{
			get
			{
				return (string) this.Get();
			}
			set
			{
				this.Set(value);
			}
		}

		public Command OkCommand
		{
			get
			{
				return Command.CreateClose();
			}
		}
	}
}
