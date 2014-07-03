using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Threading;

namespace Personal.Controles
{
    public partial class PlayPelicula : UserControl
    {
        DispatcherTimer currentPosition = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(200) };

        private double MAXIMUM_MARKER_DURATION = 3000;

        private TimelineMarkerCollection Markers { get; set; }

        private TimelineMarker currentMarker;
        public TimelineMarker CurrentMarker
        {
            get
            {
                return currentMarker;
            }
            set
            {
                currentMarker = value;
                tbMarker.Text = currentMarker != null ?
                    currentMarker.Text : string.Empty;
                tbMarker.Visibility = currentMarker != null ?
                    Visibility.Visible : Visibility.Collapsed;
            }
        }

        public static TimelineMarkerCollection CreateMockMarkers(TimeSpan duration)
        {
            TimelineMarkerCollection tmc = new TimelineMarkerCollection();
            for (double i = 400; i < duration.TotalMilliseconds; i = i + 400)
            {
                if (i < 5000 || i > 10000)
                {
                    tmc.Add(new TimelineMarker()
                    {
                        Text = string.Format("Some Text at {0}", i),
                        Time = TimeSpan.FromMilliseconds(i)
                    });
                }
            }
            return tmc;
        }

        private void CheckMarkers(double position)
        {
            if (Markers != null && Markers.Any())
            {
                CurrentMarker = (from item in Markers
                                 where item.Time != null
                                 && item.Time.TotalMilliseconds <= (position + MAXIMUM_MARKER_DURATION)
                                 && item.Time.TotalMilliseconds >= position
                                 orderby item.Time descending
                                 select item).FirstOrDefault();
            }
        }

       
        public void EjecutaPelicula()
        {
            
            //PlayPelicula play = new PlayPelicula();


            meElement.Visibility = System.Windows.Visibility.Visible;
           meElement.Source = new Uri(@"http://vnfiles.ign.com/nwvault.ign.com/fms/files/movies/53/CEP1080028433040trailer_low.wmv");
            
            meElement.MediaOpened += (s, e) =>
            {
                Markers = CreateMockMarkers(meElement.NaturalDuration.TimeSpan);
            };
            DispatcherTimer currentPosition = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(200) };
            currentPosition.Tick += (s, e) =>
                {
                    CheckMarkers(meElement.Position.TotalMilliseconds);
                };
           
            meElement.CurrentStateChanged += (s, e) =>
            {
                if (meElement.CurrentState == MediaElementState.Playing)
                    currentPosition.Start();
                else
                    currentPosition.Stop();
            };
        }


        public PlayPelicula()
        {
            InitializeComponent();
        }
    }
}
