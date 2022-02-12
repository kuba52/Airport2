namespace Conference.Data
{
    public class City
    {
        public int Id { get; set; }

        public string Destination { get; set; }

        public City(int id, string destination) =>
            (Id, Destination) = (id, destination);

    }
}
