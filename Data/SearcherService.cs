using Dapper;
using System.Data;

namespace Conference.Data
{
public sealed class SearcherService
    {
        private readonly IDbConnection _dbConnection;

        public SearcherService(IDbConnection dbConnection) =>
            _dbConnection = dbConnection;

        public IReadOnlyList<Flight> GetFlights(int skad, int dokad, DateTime kiedy)
        {
            var list = _dbConnection.Query<Flight, Plane, Flight>(
                @"SELECT f.id AS arrivalId, f.start_time AS startTime, f.arrival_time AS arrivalTime, c.destination AS dest, c2.destination AS From, p.id as planeId, p.model AS model, p.company AS comp, p.capacity
                    FROM flights f LEFT JOIN plane p on p.id = f.plane_id Join city c on c.id = f.destination Join city c2 on c2.id = f.start
                    WHERE f.start = @star AND f.destination = @cel AND f.start_time > @k;",
                (f, p) =>
                {
                    f.Plane = p;
                    return f;
                },
                new { star = skad, cel = dokad, k = kiedy},
                splitOn: "planeId").ToList();

            var list2 = _dbConnection.Query<FlightWithChange, Plane, FlightWithChange>(
                @"WITH przesiadka AS
                (SELECT id, start_time, destination, arrival_time, start
                FROM flights
                WHERE start = @star AND flights.start_time > @k)
                    SELECT z.id AS arrivalId, z.start_time AS startTime, f.arrival_time AS arrivalTime, c.destination AS dest, c3.destination AS from, z.arrival_time AS stStopover, c2.destination AS stop, f.start_time AS spStopover, f.id AS idsecond, p.id AS planeId, p.model, p.company AS comp, p.capacity
                    FROM przesiadka z JOIN flights f ON (z.destination = f.start) JOIN plane p on p.id = f.plane_id Join city c on c.id = f.destination JOIN city c2 ON z.destination = c2.id Join city c3 on c3.id = z.start
                    WHERE z.arrival_time < f.start_time AND f.destination = @cel;",
                (f, p) =>
                {
                    f.Plane = p;
                    return f;
                },
                new { k = kiedy, star = skad, cel = dokad },
                splitOn: "planeId").ToList();

            list2.ForEach(pos => list.Add(pos));
            return list;
        }

        public void Purchase(int id, int account){
            _dbConnection.Execute($"INSERT INTO passengers(flight_id, account_id) VALUES(@i, @a)", new{i = id, a = account});
        }

        public void Purchase(int id1, int id2, int account){
            _dbConnection.Execute($" BEGIN TRANSACTION ISOLATION LEVEL READ COMMITTED; INSERT INTO passengers(flight_id, account_id) VALUES (@i, @a), (@id, @a); COMMIT;",
             new {i = id1, id = id2, a = account});

        }
    }
}
