namespace Conference.Data
{
    public class Plane
    {
        public int Id { get; set; }

        public string Model {get; set; } 

        public string Company { get; set; }

        public int Capacity {get; set;}
        public Plane(int planeId, string model, string comp, int capacity) =>
            (Id, Model, Company, Capacity) = (planeId, model, comp, capacity);

    }
}
