using Sharpknife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Sharpknife.Common
{
	/// <summary>
	/// Represents a help article with some text and optional children.
	/// </summary>
	[ContentProperty("Children")]
	public class HelpArticle : Observable
	{
		/// <summary>
		/// Creates a new help article.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="text">the text</param>
		/// <param name="children">the children</param>
		public HelpArticle(string title, string text, List<HelpArticle> children)
		{
			this.title = title;
			this.text = text;

			this.children = children;
		}

		/// <summary>
		/// Creates a new help article.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="text">the text</param>
		public HelpArticle(string title, string text) : this(title, text, new List<HelpArticle>())
		{

		}

		/// <summary>
		/// Creates a new default help article.
		/// </summary>
		public HelpArticle() : this("Untitled Article", "No help text provided.")
		{

		}

		/// <summary>
		/// Gets or sets the title of the help article.
		/// </summary>
		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				this.SetNotify(ref this.title, value);
			}
		}

		/// <summary>
		/// Gets or sets the text of the help article.
		/// </summary>
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				this.SetNotify(ref this.text, value);
			}
		}

		/// <summary>
		/// Gets or sets the children of the help article.
		/// </summary>
		public List<HelpArticle> Children
		{
			get
			{
				return this.children;
			}
			set
			{
				this.SetNotify(ref this.children, value);
			}
		}

		private string title;
		private string text;

		private List<HelpArticle> children;
	}
}
