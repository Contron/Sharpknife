﻿using Sharpknife.Core;
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
			this.Name = null;
			this.Version = null;
			this.Copyright = null;

			this.GatherAssemblyInformation();
		}

		private void GatherAssemblyInformation()
		{
			//information
			var information = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

			//update
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

		public Command CloseCommand
		{
			get
			{
				return new Command(() => WindowCenter.Instance.CloseCurrentWindow());
			}
		}
	}
}
