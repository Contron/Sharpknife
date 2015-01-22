using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Common
{
	/// <summary>
	/// Represents a help article that can have descriptive text about a topic. It can also have children as sub-topics.
	/// </summary>
	public class HelpArticle
	{
		/// <summary>
		/// Creates a new help article with children.
		/// </summary>
		/// <param name="name">the name</param>
		/// <param name="text">the text</param>
		/// <param name="children">the children</param>
		public HelpArticle(string name, string text, List<HelpArticle> children)
		{
			this.Name = name;
			this.Text = text;
			this.Children = children;
		}

		/// <summary>
		/// Creates a new help article.
		/// </summary>
		/// <param name="name">the name</param>
		/// <param name="text">the text</param>
		public HelpArticle(string name, string text) : this(name, text, new List<HelpArticle>())
		{

		}

		/// <summary>
		/// The name of the article.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// The text of the article.
		/// </summary>
		public string Text
		{
			get;
			set;
		}

		/// <summary>
		/// The children of the article.
		/// </summary>
		public List<HelpArticle> Children
		{
			get;
			set;
		}
	}
}
