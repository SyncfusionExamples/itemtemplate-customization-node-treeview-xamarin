﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TreeViewXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChildTemplate : ViewCell
	{
		public ChildTemplate()
		{
			InitializeComponent ();
		}
	}
}