﻿#pragma checksum "C:\Users\Juan\Documents\SVNs\Qubit Windows Phone\Desarrollo\trunk\Personal\Personal\Views\Home.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EE74851FBBD559717E2661C88D3B452A"
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
using Personal.Controles;
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
    
    
    public partial class Home : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot pivotHome;
        
        internal Microsoft.Phone.Controls.PivotItem pivItemPersonalVideo;
        
        internal System.Windows.Controls.StackPanel grillaPersonalVideo;
        
        internal Microsoft.Phone.Controls.Pivot pivotImagenPrincipal;
        
        internal Microsoft.Phone.Controls.PivotItem pivotItem1;
        
        internal Personal.Controles.PublicitiesControl controlPublicities;
        
        internal Personal.Controles.PeliculasPorGenero peliculasHome;
        
        internal Microsoft.Phone.Controls.PivotItem pivItemGenero;
        
        internal System.Windows.Controls.ListBox lboxgeneros;
        
        internal Microsoft.Phone.Controls.PivotItem pivItemBuscar;
        
        internal System.Windows.Controls.TextBox txtBuscar;
        
        internal System.Windows.Controls.Image imgLupa;
        
        internal System.Windows.Controls.ProgressBar progressBarBusqueda;
        
        internal Personal.Controles.PeliculasPorGenero controlBuscarPeliculas;
        
        internal Microsoft.Phone.Controls.PivotItem pivItemRecomendado;
        
        internal Personal.Controles.PeliculasPorGenero recomendado;
        
        internal Microsoft.Phone.Controls.PivotItem pivItemMiCuenta;
        
        internal System.Windows.Controls.TextBlock txtIniciarSesion;
        
        internal System.Windows.Controls.TextBlock txtSuscripcion;
        
        internal System.Windows.Controls.TextBlock txtFavoritos;
        
        internal System.Windows.Controls.TextBlock txtYaVistas;
        
        internal System.Windows.Controls.TextBlock txtEstoyViendo;
        
        internal System.Windows.Controls.TextBlock txtLogOut;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Personal;component/Views/Home.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.pivotHome = ((Microsoft.Phone.Controls.Pivot)(this.FindName("pivotHome")));
            this.pivItemPersonalVideo = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("pivItemPersonalVideo")));
            this.grillaPersonalVideo = ((System.Windows.Controls.StackPanel)(this.FindName("grillaPersonalVideo")));
            this.pivotImagenPrincipal = ((Microsoft.Phone.Controls.Pivot)(this.FindName("pivotImagenPrincipal")));
            this.pivotItem1 = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("pivotItem1")));
            this.controlPublicities = ((Personal.Controles.PublicitiesControl)(this.FindName("controlPublicities")));
            this.peliculasHome = ((Personal.Controles.PeliculasPorGenero)(this.FindName("peliculasHome")));
            this.pivItemGenero = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("pivItemGenero")));
            this.lboxgeneros = ((System.Windows.Controls.ListBox)(this.FindName("lboxgeneros")));
            this.pivItemBuscar = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("pivItemBuscar")));
            this.txtBuscar = ((System.Windows.Controls.TextBox)(this.FindName("txtBuscar")));
            this.imgLupa = ((System.Windows.Controls.Image)(this.FindName("imgLupa")));
            this.progressBarBusqueda = ((System.Windows.Controls.ProgressBar)(this.FindName("progressBarBusqueda")));
            this.controlBuscarPeliculas = ((Personal.Controles.PeliculasPorGenero)(this.FindName("controlBuscarPeliculas")));
            this.pivItemRecomendado = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("pivItemRecomendado")));
            this.recomendado = ((Personal.Controles.PeliculasPorGenero)(this.FindName("recomendado")));
            this.pivItemMiCuenta = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("pivItemMiCuenta")));
            this.txtIniciarSesion = ((System.Windows.Controls.TextBlock)(this.FindName("txtIniciarSesion")));
            this.txtSuscripcion = ((System.Windows.Controls.TextBlock)(this.FindName("txtSuscripcion")));
            this.txtFavoritos = ((System.Windows.Controls.TextBlock)(this.FindName("txtFavoritos")));
            this.txtYaVistas = ((System.Windows.Controls.TextBlock)(this.FindName("txtYaVistas")));
            this.txtEstoyViendo = ((System.Windows.Controls.TextBlock)(this.FindName("txtEstoyViendo")));
            this.txtLogOut = ((System.Windows.Controls.TextBlock)(this.FindName("txtLogOut")));
        }
    }
}

