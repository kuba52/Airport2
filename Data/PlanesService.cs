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
                @"SELECT id as planeId, model AS model, company AS comp, capacity FROM plane").ToList();

        public void CreatePlane(CreatePlane model)
        {
            _dbConnection.Execute(
                $"INSERT INTO plane(model, company, capacity) VALUES (@mod, @company, @capacity);", new { mod = model.Model, company = model.Company, capacity =  model.Capacity});
        }
    }
}
