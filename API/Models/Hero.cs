namespace API.Models
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User User { get; set; }

        public string Icon { get; set; }

        public int Pv { get; set; }

        public int Atk { get; set; }

        public bool IsSwag { get; set; }

        public int NbFights { get; set; } = 0;

        public bool IsChampion { get; set; } = false;
    }
}
