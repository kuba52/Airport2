using Dapper;
using System.Data;

namespace Conference.Data
{
    public sealed class FlightsService
    {
        private readonly IDbConnection _dbConnection;

        public FlightsService(IDbConnection dbConnection) =>
            _dbConnection = dbConnection;

        public IReadOnlyList<Flight> GetArrivals(int dokad) =>
            _dbConnection.Query<Flight, Plane, Flight>(
                @"SELECT f.id AS arrivalId, f.start_time AS startTime, f.arrival_time AS arrivalTime, c.destination AS dest, c2.destination AS from, p.id as planeId, p.model AS model, p.company AS comp, p.capacity
                    FROM flights f LEFT JOIN plane p on p.id = f.plane_id Join city c on c.id = f.destination Join city c2 on c2.id = f.start
                        WHERE f.destination = @to AND f.start_time >= now()
                    ORDER BY f.start_time
                    FETCH FIRST 5 ROW ONLY;",
                (f, p) =>
                {
                    f.Plane = p;
                    return f;
                },
                new { to = dokad },
                splitOn: "planeId").
            ToList();


        public IReadOnlyList<Flight> GetDepartures(int skad) =>
            _dbConnection.Query<Flight, Plane, Flight>(
                @"SELECT f.id AS arrivalId, f.start_time AS startTime, f.arrival_time AS arrivalTime, c.destination AS dest, c2.destination AS from, p.id as planeId, p.model AS model, p.company AS comp, p.capacity
                    FROM flights f LEFT JOIN plane p on p.id = f.plane_id Join city c on c.id = f.destination Join city c2 on c2.id = f.start
                        WHERE f.start = @from AND f.start_time >= now()
                    ORDER BY f.start_time
                    FETCH FIRST 5 ROW ONLY;",
                (f, p) =>
                {
                    f.Plane = p;
                    return f;
                },
                new { from = skad },
                splitOn: "planeId").
            ToList();

        public IReadOnlyList<Flight> GetTickets(int accId) =>
            _dbConnection.Query<Flight, Plane, Flight>(
                @"SELECT pa.flight_id AS arrivalId, f.start_time AS startTime, f.arrival_time AS arrivalTime, c.destination AS dest, c2.destination AS from, p.id as planeId, p.model AS Model, p.company AS comp, p.capacity
                    FROM passengers pa JOIN flights f on pa.flight_id = f.id JOIN plane p on p.id = f.plane_id Join city c on c.id = f.destination Join city c2 on c2.id = f.start
                    WHERE pa.account_id = @aid
                    ORDER BY f.start_time;",
                (f, p) =>
                {
                    f.Plane = p;
                    return f;
                },
                new { aid = accId },
                splitOn: "planeId").
            ToList();

        public void CreateDeparture(CreateFlight model)
        {
            if (model.planeId is null)
            {
                throw new ArgumentNullException();
            }
            _dbConnection.Execute(
                $"INSERT INTO flights (start_time, arrival_time, start, plane_id, destination) VALUES (@startTime, @arrivalTime, @start, @planeId, @destination);",
                new { model.startTime, model.arrivalTime, model.start, model.planeId, model.destination });
        }
    }
}
