namespace Osrs_Hiscore.Models
{
    public class ActivityEntry : RankedEntry
    {
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        public ActivityEntry(int index, int rank, int score) : base(index, rank)
        {
            Score = score;
        }

        private int _score;
    }
}