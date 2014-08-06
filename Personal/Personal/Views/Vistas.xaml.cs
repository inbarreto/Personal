using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Personal.JsonAccess.JsonClasses;
using Newtonsoft.Json;
using Personal.Domain.Entities;
using Personal.Model;

namespace Personal.Views
{
    public partial class Vistas : PhoneApplicationPage
    {
        public Vistas()
        {
            InitializeComponent();
            this.Loaded += PeliculasFavoritos_Loaded;
        }
        void PeliculasFavoritos_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                PeliculasPorGeneroJson peliPrincipal = new PeliculasPorGeneroJson();
                peliPrincipal.session_id = ((Usuario)StateModel.ObtieneKey("Usuario")).session_id;
                peliPrincipal.named_criteria = "visto";
                string post_dataPeliculas = JsonConvert.SerializeObject(peliPrincipal);

                peliculasVistas.CargaPeliculasPost(post_dataPeliculas, "http://www.video.personal.com.ar/business.php/json/search");


            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}