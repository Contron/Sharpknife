using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Serialization;

namespace Sharpknife.Common
{
	/// <summary>
	/// Represents a help article that can have descriptive text about a topic. It can also have children as sub-topics.
	/// </summary>
	[ContentProperty("Children")]
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
		/// Creates a new empty help article.
		/// </summary>
		public HelpArticle() : this("Untitled Article", "No text provided.")
		{

		}

		/// <summary>
		/// Gets or sets the name of the article.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the text of the article.
		/// </summary>
		public string Text
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the children of the article.
		/// </summary>
		public List<HelpArticle> Children
		{
			get;
			set;
		}
	}
}
