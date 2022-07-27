using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Models
{
    internal class Car
    {
        public string Model { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }
        public int Seats { get; set; }
        public int Doors { get; set; }

        public Car(string model, string make, string year, int seats = 0, int doors = 0)
        {
            this.Model = model;
            this.Make = make;
            this.Year = year;
            this.Seats = seats;
            this.Doors = doors;
        }
    }
}
