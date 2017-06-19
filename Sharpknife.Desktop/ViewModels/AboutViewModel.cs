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
			this.Name = Assemblies.GetAttribute<AssemblyProductAttribute>()?.Product ?? "Application";
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
			get => (string) this.Get();
			set => this.Set(value);
		}

		public string Description
		{
			get => (string) this.Get();
			set => this.Set(value);
		}

		public string Version
		{
			get => (string) this.Get();
			set => this.Set(value);
		}

		public string Copyright
		{
			get => (string) this.Get();
			set => this.Set(value);
		}

		public Command CloseCommand
		{
			get => Command.Close;
		}
	}
}
