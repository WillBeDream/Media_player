namespace Media_player.Models
{
    public class Music
    {
        public string SongName { get; set; }

        public string SongPath { get; set;}

        public Music(string SongName, string SongPath)
        {
            SongName = this.SongName;
            SongPath = this.SongPath;
        }

        

    }
}