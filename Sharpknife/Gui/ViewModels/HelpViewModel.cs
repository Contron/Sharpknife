using Sharpknife.Common;
using Sharpknife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Gui.ViewModels
{
	internal class HelpViewModel : Observable
	{
		public HelpViewModel(List<HelpArticle> helpArticles)
		{
			this.HelpArticles = helpArticles;
		}

		public List<HelpArticle> HelpArticles
		{
			get
			{
				return (List<HelpArticle>) this.Get();
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
