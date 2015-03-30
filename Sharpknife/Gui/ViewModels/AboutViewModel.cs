using Sharpknife.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Gui.ViewModels
{
	internal class AboutViewModel : Observable
	{
		public AboutViewModel()
		{
			this.name = null;
			this.version = null;
			this.copyright = null;

			this.GatherAssemblyInformation();
		}

		private void GatherAssemblyInformation()
		{
			//information
			var information = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

			//update
			this.name = information.ProductName;
			this.version = string.Format("Version {0}", information.FileVersion);
			this.copyright = string.Format("Copyright {0}", information.LegalCopyright);
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.SetNotify(ref this.name, value);
			}
		}

		public string Version
		{
			get
			{
				return this.version;
			}
			set
			{
				this.SetNotify(ref this.name, value);
			}
		}

		public string Copyright
		{
			get
			{
				return this.copyright;
			}
			set
			{
				this.SetNotify(ref this.name, value);
			}
		}

		public Command CloseCommand
		{
			get
			{
				return new Command(() => WindowCenter.Instance.CloseCurrentWindow());
			}
		}

		private string name;
		private string version;
		private string copyright;
	}
}
