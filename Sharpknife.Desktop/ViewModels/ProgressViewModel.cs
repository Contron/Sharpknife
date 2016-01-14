using Sharpknife.Desktop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.ViewModels
{
	class ProgressViewModel : Observable
	{
		public ProgressViewModel()
		{
			this.Title = "Title";
			this.Status = "Status";

			this.Progress = 0;
			this.Maximum = 100;

			this.Completed = false;
		}

		private void Cancel()
		{
			// Implemented at a later date.
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

		public string Status
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

		public int Progress
		{
			get
			{
				return (int) this.Get();
			}
			set
			{
				this.Set(value);

				this.Notify(nameof(this.Indeterminate));
			}
		}

		public int Maximum
		{
			get
			{
				return (int) this.Get();
			}
			set
			{
				this.Set(value);
			}
		}

		public bool Completed
		{
			get
			{
				return (bool) this.Get();
			}
			set
			{
				this.Set(value);
			}
		}

		public bool Indeterminate
		{
			get
			{
				return this.Progress <= 0;
			}
		}

		public Command CancelCommand
		{
			get
			{
				return new Command(this.Cancel, () => false);
			}
		}
	}
}
