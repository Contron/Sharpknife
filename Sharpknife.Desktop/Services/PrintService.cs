using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a print service to print basic documents.
	/// </summary>
	public class PrintService
	{
		private PrintService()
		{

		}

		/// <summary>
		/// Prints a document with the specified title and text.
		/// </summary>
		/// <param name="title">the title</param>
		/// <param name="text">the text</param>
		public void Print(string title, string text)
		{
			var dialog = new PrintDialog()
			{
				CurrentPageEnabled = false,
				SelectedPagesEnabled = false,
				UserPageRangeEnabled = false
			};
			var result = dialog.ShowDialog();

			if (result != null)
			{
				if (!result.Value)
				{
					return;
				}
			}

			var date = DateTime.Now.ToString("dddd d MMMM yyy, h:mm:ss tt");

			var document = new FlowDocument()
			{
				ColumnGap = 0,
				PageWidth = dialog.PrintableAreaWidth,
				PageHeight = dialog.PrintableAreaHeight,
				PagePadding = new Thickness(25),
				Blocks =
				{
					new Paragraph()
					{
						TextAlignment = TextAlignment.Center,
						Inlines =
						{
							new Run(title)
							{
								FontSize = 32,
								FontWeight = FontWeights.Bold
							},
							new LineBreak(),
							new Run(date)
						}
					},
					new Paragraph()
					{
						FontFamily = new FontFamily("Consolas"),
						FontSize = 16,
						Inlines =
						{
							new Run(text)
						}
					}
				}
			};

			document.ColumnWidth = (document.PageWidth - document.ColumnGap) - (document.PagePadding.Left - document.PagePadding.Right);

			var paginator = document as IDocumentPaginatorSource;

			if (paginator != null)
			{
				dialog.PrintDocument(paginator.DocumentPaginator, title);
			}
		}

		/// <summary>
		/// Gets the instance of the print service.
		/// </summary>
		public static PrintService Instance
		{
			get
			{
				return PrintService.instance;
			}
		}

		private static readonly PrintService instance = new PrintService();
	}
}
