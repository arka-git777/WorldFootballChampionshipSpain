namespace WorldFootballChampionshipSpain.DAL.Enteties
{
    public class Team
    {
        public int Id { get; set; }
        public required string TeamName { get; set; }
        public required string City { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Draws { get; set; }
        public int ScoredGoals { get; set; }
        public int LostGoals { get; set; }
    }
}
