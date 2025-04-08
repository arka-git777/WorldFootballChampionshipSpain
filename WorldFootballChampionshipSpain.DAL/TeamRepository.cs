using WorldFootballChampionshipSpain.DAL.Enteties;

namespace WorldFootballChampionshipSpain.DAL
{
    public class TeamRepository
    {
        private readonly AppDbContext _context;
        public TeamRepository()
        {
            _context = new AppDbContext();
        }
        public void Add(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }
        /*public void AddRange(List<Stream> stream)
        {
            _context.Students.AddRange(stream);
            _context.SaveChanges();
        }*/
        public void Update(Team team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
        }
        public void Delete(Team team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }
        public Team GetById(int id)
        {
            return _context.Teams.FirstOrDefault(x => x.Id == id);
        }
        public Team GetByNameCity(string name, string city)
        {
            return _context.Teams.FirstOrDefault(x => x.TeamName == name && x.City == city);
        }
        public Team GetByName(string name)
        {
            return _context.Teams.FirstOrDefault(x => x.TeamName.ToUpper() == name);
        }
        public IEnumerable<Team> GetAll()
        {
            return _context.Teams.ToList();
        }
        public IEnumerable<Team> GetAllByCity(string city)
        {
            return _context.Teams.Where(x => x.City.ToUpper() == city.ToUpper());
        }
    }
}
