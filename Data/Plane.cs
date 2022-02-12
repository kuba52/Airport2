namespace Conference.Data
{
    public class Plane
    {
        public int Id { get; set; }

        public string Company { get; set; }

        public int Capacity {get; set;}
        public Plane(int planeId, string comp, int capacity) =>
            (Id, Company, Capacity) = (planeId, comp, capacity);

    }
}
