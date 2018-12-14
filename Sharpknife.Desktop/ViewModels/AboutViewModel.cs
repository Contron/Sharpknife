using System.Reflection;
using Sharpknife.Desktop.Core;
using Sharpknife.Utilities;

namespace Sharpknife.Desktop.ViewModels
{
	class AboutViewModel : Observable
	{
		public AboutViewModel()
		{
			this.Name = Assemblies.GetAttribute<AssemblyProductAttribute>()?.Product ?? "Application";

			this.Version = $"Version {Assemblies.GetAttribute<AssemblyFileVersionAttribute>()?.Version ?? "Unknown"}";
			this.Copyright = $"Copyright {Assemblies.GetAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? "Unavailable"}";
		}

		public string Name
		{
			get => this.name;
			set => this.Set(ref this.name, value);
		}

		public string Version
		{
			get => this.version;
			set => this.Set(ref this.version, value);
		}

		public string Copyright
		{
			get => this.copyright;
			set => this.Set(ref this.copyright, value);
		}

		public Command CloseCommand => Command.Close;

		private string name = null;

		private string version = null;
		private string copyright = null;
	}
}
