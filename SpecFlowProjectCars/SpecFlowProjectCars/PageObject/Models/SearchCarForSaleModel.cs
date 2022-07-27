namespace SpecFlowProjectCars.PageObject.Models
{
    internal class SearchCarForSaleModel
    {
        public string UseType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public string Distance { get; set; }
        public string Zip { get; set; }

        public SearchCarForSaleModel(string useType = "New & used cars",
            string make = "All makes", string model = "All models",
            string price = "No max price",
            string distance = "10 miles", string zip = "0")
        {
            this.UseType = useType;
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Distance = distance;
            this.Zip = zip;
        }
    }
}
