using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Personal.JsonAccess.JsonClasses;
using Personal.Model;
using Personal.Domain.Entities;
using System.Windows.Media;

namespace Personal.Controles
{
    public partial class PublicitiesControl : UserControl
    {
        public PublicitiesControl()
        {
            InitializeComponent();
        }

      
        private void imgPeliculaPrincipal_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txtContentid.Tag == null)
            {
                WebBrowserTask webBrowserTask = new WebBrowserTask();
                webBrowserTask.Uri = new Uri(imgPeliculaPrincipal.Tag.ToString());
                webBrowserTask.Show();
            }
            else
            {
                StateModel.CargaKey("idPelicula", txtContentid.Tag.ToString());
                (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri(@"/Views/FichaTecnica.xaml", UriKind.Relative));                 
            
            }
                
        }
    }
}
