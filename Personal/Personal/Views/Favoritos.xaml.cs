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
using Personal.JsonAccess;

namespace Personal.Views
{
    public partial class Favoritos : PhoneApplicationPage
    {
        public Favoritos()
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
                peliPrincipal.named_criteria = "favoritos";
                string post_dataPeliculas = JsonConvert.SerializeObject(peliPrincipal);

                peliculasFavoritos.CargaPeliculasPost(post_dataPeliculas, URL.MenuCategoria);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}