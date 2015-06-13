﻿using Sharpknife.Desktop.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sharpknife.Desktop.Views
{
	/// <summary>
	/// Represents a message window to display information to the user.
	/// </summary>
	public partial class MessageView : Window
	{
		/// <summary>
		/// Creates a new message view.
		/// </summary>
		public MessageView()
		{
			this.InitializeComponent();
		}
	}
}
