using System.Data;
using Dapper;
namespace Conference.Data
{
    public sealed class CitiesService
    {
        private readonly IDbConnection _dbConnection;

        public CitiesService(IDbConnection dbConnection) =>
            _dbConnection = dbConnection;

        public IReadOnlyList<City> GetCities() =>
            _dbConnection.Query<City>(@"SELECT id, destination FROM city").ToList();

        public void CreateCity(CreateCity model)
        {
            _dbConnection.Execute(
                $"INSERT INTO city(destination) VALUES (@destination);", new { destination = model.Destination});
        }
    }
}
