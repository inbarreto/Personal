﻿#pragma checksum "E:\Proyects\personal\Personal\Personal\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "95F6EF293F2CB69FA2A3A58AF5A2E688"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Expression.Interactivity.Core;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Personal {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Expression.Interactivity.Core.DataStateBehavior StateBehavior;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.VisualStateGroup DataStates;
        
        internal System.Windows.VisualState Loading;
        
        internal System.Windows.VisualState SiCargado;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock txtPersonal;
        
        internal System.Windows.Controls.TextBlock txtPersonalvideo;
        
        internal System.Windows.Controls.ProgressBar loadingProgress;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Personal;component/Views/MainPage.xaml", System.UriKind.Relative));
            this.StateBehavior = ((Microsoft.Expression.Interactivity.Core.DataStateBehavior)(this.FindName("StateBehavior")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.DataStates = ((System.Windows.VisualStateGroup)(this.FindName("DataStates")));
            this.Loading = ((System.Windows.VisualState)(this.FindName("Loading")));
            this.SiCargado = ((System.Windows.VisualState)(this.FindName("SiCargado")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txtPersonal = ((System.Windows.Controls.TextBlock)(this.FindName("txtPersonal")));
            this.txtPersonalvideo = ((System.Windows.Controls.TextBlock)(this.FindName("txtPersonalvideo")));
            this.loadingProgress = ((System.Windows.Controls.ProgressBar)(this.FindName("loadingProgress")));
        }
    }
}

