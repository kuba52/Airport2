using Dapper;
using System.Data;

namespace Conference.Data
{
    public sealed class PlanesService
    {
        private readonly IDbConnection _dbConnection;

        public PlanesService(IDbConnection dbConnection) =>
            _dbConnection = dbConnection;

        public IReadOnlyList<Plane> GetPlanes() =>
            _dbConnection.Query<Plane>(
                @"SELECT id as planeId, company AS comp, capacity FROM plane").ToList();

        public void CreatePlane(CreatePlane model)
        {
            _dbConnection.Execute(
                $"INSERT INTO plane(company, capacity) VALUES (@company, @capacity);", new { model.Company, model.Capacity });
        }
    }
}
