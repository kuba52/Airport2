namespace Conference.Data
{
    public class FlightWithChange :Flight
    {
        public DateTime startStopover { get; set; }

        public string whereStopover { get; set; }

        public DateTime stopStopover { get; set; }

        public int secondId { get; set; }

        public FlightWithChange(int arrivalId, DateTime startTime, DateTime arrivalTime, string dest, string from, DateTime stStopover,
            string stop, DateTime spStopover, int idSecond) : base(arrivalId, startTime, arrivalTime, dest, from)
        {
            (startStopover, whereStopover, stopStopover, secondId) = (stStopover, stop, spStopover, idSecond);
        }
    }
}
