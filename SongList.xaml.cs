using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ItunesApi.Models;
using ItunesApi.Views;
using ItunesApi.DAL;

namespace ItunesApi
{
    /// <summary>
    /// Interaction logic for SongList.xaml
    /// </summary>
    public partial class SongList : Window
    {
        public SongList()
        {
            InitializeComponent();
            
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SongRepository songRepository = new SongRepository();
            SortedSet<SongModel> songs = new SortedSet<SongModel>(songRepository.GetSongs());

            foreach (var song in songs)
            {
                //System.Diagnostics.Debug.WriteLine("{0} - {1}", song.Artist, song.Song);
                txtInput.Text +=  song.Artist + " - " + song.Song + Environment.NewLine;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SongRepository songRepository = new SongRepository();
            SortedSet<SongModel> songs = new SortedSet<SongModel>(songRepository.DeleteSongs());
            ClearButton.IsEnabled = false;
        }
    }
}
