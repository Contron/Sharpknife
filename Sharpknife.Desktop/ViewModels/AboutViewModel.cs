using System.Reflection;
using Sharpknife.Desktop.Core;
using Sharpknife.Utilities;

namespace Sharpknife.Desktop.ViewModels
{
	class AboutViewModel : Observable
	{
		public AboutViewModel()
		{
			this.Name = null;
			this.Description = null;

			this.Version = null;
			this.Copyright = null;

			this.Populate();
		}

		private void Populate()
		{
			this.Name = Assemblies.GetAttribute<AssemblyProductAttribute>()?.Product;
			this.Description = Assemblies.GetAttribute<AssemblyDescriptionAttribute>()?.Description;

			this.Version = $"Version {Assemblies.GetAttribute<AssemblyFileVersionAttribute>()?.Version ?? "Unknown"}";
			this.Copyright = $"Copyright {Assemblies.GetAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? "Unavailable"}";

			if (string.IsNullOrEmpty(this.Description))
			{
				this.Description = $"{this.Name} desktop application";
			}
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

		public string Description
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
				return Command.Close;
			}
		}
	}
}
