namespace APP.Models
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User User { get; set; }

        public string Icon { get; set; }

        public int Pv { get; set; } = 20;

        public int Atk { get; set; } = 1;

        public bool IsSwag { get; set; } = false;

        public int NbFights { get; set; } = 0;

        public bool IsChampion { get; set; } = false;
    }
}
