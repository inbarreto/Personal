﻿#pragma checksum "C:\Users\Juan\Documents\SVNs\Qubit Windows Phone\Desarrollo\trunk\Personal\Personal\Views\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "846A9D9168103D8FF790D296A392CDA0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Personal.Views {
    
    
    public partial class Login : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.TextBlock lblNumeroLinea;
        
        internal System.Windows.Controls.TextBox txtNroLinea;
        
        internal System.Windows.Controls.PasswordBox txtClavePersonal;
        
        internal System.Windows.Controls.Button btnAceptar;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Personal;component/Views/Login.xaml", System.UriKind.Relative));
            this.lblNumeroLinea = ((System.Windows.Controls.TextBlock)(this.FindName("lblNumeroLinea")));
            this.txtNroLinea = ((System.Windows.Controls.TextBox)(this.FindName("txtNroLinea")));
            this.txtClavePersonal = ((System.Windows.Controls.PasswordBox)(this.FindName("txtClavePersonal")));
            this.btnAceptar = ((System.Windows.Controls.Button)(this.FindName("btnAceptar")));
        }
    }
}

