namespace SpecFlowProjectCars.PageObject.Models
{
    internal class Car
    {
        public string Model { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }
        public string Trim { get; set; }
        public int Seats { get; set; }
        public int Doors { get; set; }
        public string Price { get; set; }

        public Car(string model, string make, string year,string trim, int seats = 0, int doors = 0, string price = null)
        {
            this.Model = model;
            this.Make = make;
            this.Year = year;
            this.Seats = seats;
            this.Doors = doors;
            this.Trim = trim;
            this.Price = price;
        }

        public bool IsCarPriceHigher(double anotherPrice)
        {
            return double.Parse(this.Price.Trim('$')) > anotherPrice;
        }
    }        
}
