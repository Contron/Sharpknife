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
			this.helpArticles = helpArticles;
		}

		public List<HelpArticle> HelpArticles
		{
			get
			{
				return this.helpArticles;
			}
			set
			{
				this.SetNotify(ref this.helpArticles, value);
			}
		}

		public Command CloseCommand
		{
			get
			{
				return new Command(() => WindowCenter.Instance.CloseCurrentWindow());
			}
		}

		private List<HelpArticle> helpArticles;
	}
}
