namespace Conference.Data
{
    public class Flight
    {
        public int Id { get; set; }

        public Plane? Plane { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string From { get; set; }

        public string Destination { get; set; }

        public Flight(int arrivalId, DateTime startTime, DateTime arrivalTime, string dest, string from) =>
            (Id, StartTime, ArrivalTime, Destination, From) = (arrivalId, startTime, arrivalTime, dest, from);


    }
}
