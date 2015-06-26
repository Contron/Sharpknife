using Sharpknife.Desktop.Core;
using Sharpknife.Desktop.Services;
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
	internal class AboutViewModel : Observable
	{
		public AboutViewModel()
		{
			this.Name = null;
			this.Version = null;
			this.Copyright = null;

			this.GatherAssemblyInformation();
		}

		private void GatherAssemblyInformation()
		{
			var information = Assemblies.GetInformation();

			this.Name = information.ProductName;
			this.Version = string.Format("Version {0}", information.FileVersion);
			this.Copyright = string.Format("Copyright {0}", information.LegalCopyright);
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
				return new Command(() => WindowService.Instance.CloseCurrent());
			}
		}
	}
}
