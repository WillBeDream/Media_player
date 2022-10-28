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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Media_player.Models;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;


namespace Media_player.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public ObservableCollection<Music> MusicList { get; set; }

        private Music selected_music;
        public MainWindow()
        {
            MusicList = new ObservableCollection<Music>();
            InitializeComponent();
            

        }

        private void Button_Click_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Audio files (*.mp3)|*.mp3|All Files (*.*)|*.*";

            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;

                MusicList.Add(new Music(dlg.FileName));

                myMediaElement.Source = new Uri(selectedFileName);

                myMediaElement.Play();
            }

        }

       public Music SelectedMusic { 
            get { return selected_music; }
            set
            {
                selected_music = value;
                OnPropertyChanged("SelectedMusic");
            }
        }
        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Play();
        }

        private void Button_Click_stop(object sender, RoutedEventArgs e)
        {
            myMediaElement.Stop();
        }

        private void Button_Click_Pause(object sender, RoutedEventArgs e)
        {
            myMediaElement.Pause();
        }

        //private void MusicsList_add()
        //{
        //    var dir = Directory.GetFiles("C:\\Songs", "*mp3");
        //    foreach (var file in dir)
        //    {
        //        var fileinfo = new FileInfo(file);
        //        MusicList.Add(new Music(fileinfo.Name, fileinfo.FullName));
        //    }
        //}

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myMediaElement.Source= new Uri(selected_music.SongName);
        }
    }


}

   

       

        





