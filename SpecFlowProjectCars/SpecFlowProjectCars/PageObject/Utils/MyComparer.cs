using CarsPageObject.Models;
using ObjectsComparer;
using SpecFlowProjectCars.PageObject.Models;

namespace SpecFlowProjectCars.PageObject.Utils
{
    class MyComparer : AbstractValueComparer<Car>
    {

         public override bool Compare(Car obj1, Car obj2, ComparisonSettings settings)
         {
            return (obj1.Make.Equals(obj2.Make)) && (obj1.Year.Equals(obj2.Year))
            && (obj1.Seats.Equals(obj2.Seats)) && (obj1.Model.Equals(obj2.Model))
            && (obj1.Doors.Equals(obj2.Doors));
         }        
    }
}
