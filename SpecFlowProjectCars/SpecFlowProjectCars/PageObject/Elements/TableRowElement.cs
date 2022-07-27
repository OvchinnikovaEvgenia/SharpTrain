using OpenQA.Selenium;

namespace SpecFlowProjectCars.PageObject.Elements
{
    internal class TableRowElement : BaseElement
    {
        public TableRowElement(By locator, string name) : base(locator, name) { }

        public List<Int32> NumbersFromRow(string separator) 
        {
            this.WaitForPresense();
            List<Int32> numbers = new List<Int32>();
            this.FindElements().ForEach(
                el => numbers.Add(
                    int.Parse(
                        el.Text.Trim().Split(separator)[0])));
            return numbers;
        }

        public List<Int32> NumbersFromRow()
        {
            this.WaitForPresense();
            List<Int32> numbers = new List<Int32>();
            this.FindElements().ForEach(
                el => numbers.Add(int.Parse(el.Text.Trim())));
            return numbers;

        }
    }
}
