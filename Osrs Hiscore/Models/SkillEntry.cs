namespace Osrs_Hiscore.Models
{
    public class SkillEntry : RankedEntry
    {
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged();
            }
        }
        public int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                OnPropertyChanged();
            }
        }

        public SkillEntry(int index, int rank, int level, int experience) : base(index, rank)
        {
            Level = level;
            Experience = experience;
        }

        private int _level;
        private int _experience;
    }
}