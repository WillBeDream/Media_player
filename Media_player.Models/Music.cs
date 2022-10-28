using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Media_player.Models
{
    public class Music : INotifyPropertyChanged
    {
        public string songName;

        public string SongName 
        {
            get { return songName; } 
            set
            {
                songName = value;
                OnPropertyChanged("SongName");
            }
        }

        public Music(string songName)
        {
            this.songName = songName;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}