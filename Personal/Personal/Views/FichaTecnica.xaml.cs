﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Personal.Domain.Entities;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;
using System.Net.NetworkInformation;
using Personal.Model;
using Newtonsoft.Json.Linq;
using Personal.JsonAccess;
using Personal.JsonAccess.JsonClasses;
using Newtonsoft.Json;
using Personal.Domain.Enums;


namespace Personal.Views
{
    public partial class FichaTecnica : PhoneApplicationPage
    {
        public FichaTecnica()
        {
            InitializeComponent();
            this.Loaded += FichaTecnica_Loaded;                        
        }
        string peliculaID = string.Empty;
        Usuario usuario = new Usuario();
        Pelicula peliculaCargada = new Pelicula();                        
        void FichaTecnica_Loaded(object sender, RoutedEventArgs e)
        {

            peliculaID = StateModel.ObtieneKey("idPelicula").ToString();

            usuario = StateModel.ObtieneKey("Usuario") as Usuario;

            if (peliculaID.Length > 6)
            {
                PeliculaJson peliculaJson = new PeliculaJson();
                peliculaJson.element_id = peliculaID;
                peliculaJson.session_id = usuario != null ? usuario.session_id : string.Empty;

                string postJsonPelicula = JsonConvert.SerializeObject(peliculaJson);
                CargaDatosPeliculaPost(postJsonPelicula, URL.ElementPelicula);
            }
            else
            {
                PeliculaPublicitiesJson peliculaJson = new PeliculaPublicitiesJson();
                peliculaJson.ref_id = peliculaID;
                peliculaJson.session_id = usuario != null ? usuario.session_id : string.Empty;

                string postJsonPelicula = JsonConvert.SerializeObject(peliculaJson);
                CargaDatosPeliculaPost(postJsonPelicula, URL.ElementPelicula);
            }
        }

        public void CargaPeliculaObjetoConJson(string jsonPelicula)
        {            
            peliculaCargada  = JsonModel.ConvierteJsonAPelicula(jsonPelicula);
            ratingControl.EstrellasActivas(peliculaCargada.ranking);
            datosPelicula.DataContext = peliculaCargada;
            
            foreach (string item in peliculaCargada.categorie)
            {
                catego.Text += item+" ";
            }        
            cargaInformation(peliculaCargada.information);

            DescripcionPeliculaImagenes();
        }

        private void DescripcionPeliculaImagenes()
        {
            if (peliculaCargada.subtitled == 1)
            {
                imgSubtitulo.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                imgSubtitulo.Visibility = System.Windows.Visibility.Collapsed;
            }
            if (peliculaCargada.available_in_hd == 1)
            {
                imgHD.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                imgHD.Visibility = System.Windows.Visibility.Collapsed;
            }

            if (peliculaCargada.classification == "ATP")
            {
                imgATP.Source = new BitmapImage(new Uri(@"/Imagenes/ATP.png", UriKind.Relative));
            }
            else if (peliculaCargada.classification == "13")
            {
                imgATP.Source = new BitmapImage(new Uri(@"/Imagenes/+13.png", UriKind.Relative));
            }
            else if (peliculaCargada.classification == "16")
            {
                imgATP.Source = new BitmapImage(new Uri(@"/Imagenes/+16.png", UriKind.Relative));
            }
            else if (peliculaCargada.classification == "18")
            {
                imgATP.Source = new BitmapImage(new Uri(@"/Imagenes/+18.png", UriKind.Relative));
            }
            txtLenguaje.Text = peliculaCargada.default_language.ToUpper();
            
            BitmapImage imag;
            if (peliculaCargada.favorite)
                imag = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"/Imagenes/fav-activo.png", UriKind.RelativeOrAbsolute));
            else
                imag = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"/Imagenes/fav-inactivo.png", UriKind.RelativeOrAbsolute));
            imgFavorito.Source = imag;
            
        }


        private void cargaInformation(List<Information> information)
        {
            txtEstrellas.Text = "Estrellas: ";
            foreach (Information item in information)
	        {
                if (item.field_name == "Director")
                    datoDirector.Text = item.value;
                else
                    if (item.field_name == "Artista")
                    {
                        if (txtEstrellas.Text == "Estrellas: ")                        
                            txtEstrellas.Text += item.value;
                        else
                            txtEstrellas.Text +=", "+item.value;
                    }
	        }    
        }

        private void imgVerAhora_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (usuario == null || usuario.session_id ==string.Empty)
            {
                NavigationService.Navigate(new Uri("/Views/Login.xaml", UriKind.Relative));
                
            }
            else
            {
                if (usuario.suscription_id == ((int)Enums.Enumsuscripcion.Activar).ToString())
                {
                    MessageBox.Show(string.Format("Estás por ver {0}" + Environment.NewLine + "calificación {1}" + Environment.NewLine + "costo $ {2}" + Environment.NewLine, peliculaCargada.title, peliculaCargada.classification, peliculaCargada.price_sd), "Atención", MessageBoxButton.OK);
                    BitmapImage imag = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"/Imagenes/ver ahora-hover.png", UriKind.RelativeOrAbsolute));
                    imgVerAhora.Source = imag;

                    bool hayRed = NetworkInterface.GetIsNetworkAvailable();
                    if (hayRed)
                    {
                        PlayJson playJson = new PlayJson();
                        playJson.content_id = peliculaID;
                        playJson.session_id = usuario.session_id;
                        playJson.device_type = "windows_phone";
                        string jsonPostPlay = JsonConvert.SerializeObject(playJson);
                        CargaPlayPost(jsonPostPlay, URL.Play);
                    }
                    else
                    {
                        MessageBox.Show("Para poder ver la película necesita acceso a internet.");
                        imag = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"/Imagenes/ver ahora-inactivo.png", UriKind.RelativeOrAbsolute));
                        imgVerAhora.Source = imag;
                    }
            
                }
            }            
        }

        #region JsonLoad
        public void CargaDatosPeliculaPost(string postdata, string url)
        {
            JsonRequest PeliculaRequest = new JsonRequest();
            PeliculaRequest.Completed += new EventHandler(handleResponsePelicula);
            PeliculaRequest.beginRequest(postdata, url);
        }
        public void handleResponsePelicula(object sender, EventArgs args)
        {
            JsonRequest responseObject = sender as JsonRequest;
            string response = responseObject.ResponseTxt;
            CargaPeliculaObjetoConJson(response);
            //parse it
        }


        public void CargaPlayPost(string postdata, string url)
        {
            progressBarVer.Visibility = System.Windows.Visibility.Visible;
            progressBarVerImg.Visibility = System.Windows.Visibility.Visible;
            imgVerAhora.Visibility = System.Windows.Visibility.Collapsed;
            imgVer.Visibility = System.Windows.Visibility.Collapsed;
            BitmapImage imag = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"/Imagenes/ver ahora-inactivo.png", UriKind.RelativeOrAbsolute));
            imgVerAhora.Source = imag;
            JsonRequest loginRequest = new JsonRequest();
            loginRequest.Completed += new EventHandler(handleResponsePlay);
            loginRequest.beginRequest(postdata, url);
        }
        public void handleResponsePlay(object sender, EventArgs args)
        {
            JsonRequest responseObject = sender as JsonRequest;
            string response = responseObject.ResponseTxt;
            this.CargaPlayConJson(response);
            //parse it
        }
        #endregion JsonLoad
        private void CargaPlayConJson(string jsonString)
        {
            try
            {
                progressBarVer.Visibility = System.Windows.Visibility.Collapsed;
                progressBarVerImg.Visibility = System.Windows.Visibility.Collapsed;
                imgVerAhora.Visibility = System.Windows.Visibility.Visible;
                imgVer.Visibility = System.Windows.Visibility.Visible;
                Play play = JsonModel.ConvierteJsonPlay(jsonString);                
                MediaPlayerLauncher mediaPlayerLauncher = new MediaPlayerLauncher();
                mediaPlayerLauncher.Media = new Uri(play.direct_url, UriKind.Absolute);
                mediaPlayerLauncher.Location = MediaLocationType.Data;
                mediaPlayerLauncher.Controls = MediaPlaybackControls.Pause | MediaPlaybackControls.Stop;
                mediaPlayerLauncher.Orientation = MediaPlayerOrientation.Landscape;

                mediaPlayerLauncher.Show();

            }
            catch (Exception ex)
            {                
                throw ex;
            }


        }

        private void imgFavorito_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                usuario = StateModel.ObtieneKey("Usuario") as Usuario;
                if (usuario != null)
                {

                    BitmapImage imag;
                    if (peliculaCargada != null)
                    {
                        if (peliculaCargada.favorite)
                            peliculaCargada.favorite = false;
                        else
                            peliculaCargada.favorite = true;


                        if (peliculaCargada.favorite)
                            imag = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"/Imagenes/fav-activo.png", UriKind.RelativeOrAbsolute));
                        else
                            imag = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"/Imagenes/fav-inactivo.png", UriKind.RelativeOrAbsolute));
                        imgFavorito.Source = imag;
                        FavoritosAgregarJson favoritos = new FavoritosAgregarJson();
                        favoritos.content_id = peliculaCargada.ref_id.ToString();
                        favoritos.session_id = usuario.session_id;
                        string jsonFavoritos = JsonConvert.SerializeObject(favoritos);

                        this.CargaFavoritoPost(jsonFavoritos, URL.AddFavoritos);

                    }
                }
                else
                {
                    MessageBox.Show("Para poder agregar a favoritos debe estar logeado", "error", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CargaFavoritoPost(string postdata, string url)
        {
            JsonRequest loginRequest = new JsonRequest();
            loginRequest.Completed += new EventHandler(handleResponseFavorito);
            loginRequest.beginRequest(postdata, url);
        }
        public void handleResponseFavorito(object sender, EventArgs args)
        {
            JsonRequest responseObject = sender as JsonRequest;
            string response = responseObject.ResponseTxt;
            //parse it
        }

        private void imgVerAhora_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }
      

    }
}