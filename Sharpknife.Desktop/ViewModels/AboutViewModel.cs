using Sharpknife.Desktop.Core;
using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.ViewModels
{
	class AboutViewModel : Observable
	{
		public AboutViewModel()
		{
			this.Name = null;
			this.Version = null;
			this.Copyright = null;

			this.Populate();
		}

		private void Populate()
		{
			var information = Assemblies.GetInformation();

			this.Name = information.ProductName;
			this.Version = $"Version {information.FileVersion}";
			this.Copyright = $"Copyright {information.LegalCopyright}";
		}

		public string Name
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

		public string Version
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

		public string Copyright
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
