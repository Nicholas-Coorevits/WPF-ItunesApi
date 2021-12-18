using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ItunesApi.Views;
using ItunesApi.DAL;
using ItunesApi.Models;

namespace ItunesApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int i = 0;
        SongRepository songRepository = new SongRepository();
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            previousSongButton.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var json = ApiProcessor.getSongs();

            title.Text = $"{json.feed.title}";
            artistName.Text = $"artist : {json.feed.results[i].artistName} ";
            songName.Text = $"Song : {json.feed.results[i].name}";
            artistUrl.Text = $"Link : {json.feed.results[i].artistUrl}";

            string newImage = json.feed.results[i].artworkUrl100.Replace("100x100", "330x330");
            var uriSource = new Uri(newImage);
            ArtistImage.Source = new BitmapImage(uriSource);
            

        }


        private void previousSongButton_Click(object sender, RoutedEventArgs e)
        {
            i -= 1;
            if (i < 9)
            {
                nextSongButton.IsEnabled = true;
                var json = ApiProcessor.getSongs();

                title.Text = $"{json.feed.title}";
                artistName.Text = $"artist : {json.feed.results[i].artistName} ";
                songName.Text = $"Song : {json.feed.results[i].name}";
                artistUrl.Text = $"Link : {json.feed.results[i].artistUrl}";

                string newImage = json.feed.results[i].artworkUrl100.Replace("100x100", "330x330");
                var uriSource = new Uri(newImage);
                ArtistImage.Source = new BitmapImage(uriSource);
            }

            if (i == 0)
            {
                previousSongButton.IsEnabled = false;
            }

        }

        private void nextSongButton_Click(object sender, RoutedEventArgs e)
        {
            i += 1;
            if (i > 0 )
            {
                previousSongButton.IsEnabled = true;
                var json = ApiProcessor.getSongs();

                title.Text = $"{json.feed.title}";
                artistName.Text = $"artist : {json.feed.results[i].artistName} ";
                songName.Text = $"Song : {json.feed.results[i].name}";
                artistUrl.Text = $"Link : {json.feed.results[i].artistUrl}";

                string newImage = json.feed.results[i].artworkUrl100.Replace("100x100", "380x380");
                var uriSource = new Uri(newImage);
                ArtistImage.Source = new BitmapImage(uriSource);
            }
            
            if (i == 9)
            {
                nextSongButton.IsEnabled = false;
            }
        }

        

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            
            var json = ApiProcessor.getSongs();

            SongModel song = new SongModel { Artist = json.feed.results[i].artistName, Song = json.feed.results[i].name };
            songRepository.InsertSong(song);
        }

        private void savedSong_Click(object sender, RoutedEventArgs e)
        {
            SongList songList = new SongList();

            songList.Show();
        }
    }
}
