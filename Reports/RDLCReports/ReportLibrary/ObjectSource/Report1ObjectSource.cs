namespace ReportLibrary.ObjectSource
{
    public class Report1ObjectSource
    {
        public Report1ObjectSource()
        {
            this.Sales = new List<Sale>()
            {
                new Sale(DateTime.Parse("01/01/2024"),"ItemName1",1.00),
                new Sale(DateTime.Parse("01/01/2024"),"ItemName2",2.00),
                new Sale(DateTime.Parse("02/21/2024"),"ItemName3",3.03),
                new Sale(DateTime.Parse("03/02/2024"),"ItemName1",4.00),
                new Sale(DateTime.Parse("02/11/2024"),"ItemName2",3.20),
                new Sale(DateTime.Parse("01/21/2024"),"ItemName3",4.00),
                new Sale(DateTime.Parse("01/25/2024"),"ItemName4",6.00),
                new Sale(DateTime.Parse("01/30/2024"),"ItemName1",1.00),
            };
        }

        public List<Sale> Sales { get; set; }
    }

    public record Sale(DateTime dateSold, string itemName, double amount);
}
