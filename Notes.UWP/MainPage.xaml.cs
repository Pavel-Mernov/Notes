﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms;
using Notes;

namespace Notes.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            Forms.SetFlags("Shell_UWP_Experimental");

            this.InitializeComponent();

            LoadApplication(new Notes.App());
        }
    }
}
