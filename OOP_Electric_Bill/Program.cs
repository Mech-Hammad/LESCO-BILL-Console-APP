namespace OOP_Electric_Bill
{
    // Not using an interface since all the ConsumerBills are very similar in nature and thus we can use
    // abstract base class instead of an interface. Would have used an interface if the bill was required
    //to be calculated for disimiliar things
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This Program calculates the Electric Bill of the user");

            //Take type of user as input
            Console.Write("Enter Consumer Type (r for resendential, c for commercial): ");
            string consumerType = Console.ReadLine().ToLower(); // Convert to lowerase to avoid case issues

            //ALso ask whether a user is a taxpayer or not
            Console.Write("Are you a TaxPayer (y/n): ");
            string taxPayer = Console.ReadLine().ToLower(); // Convert to lowerase to avoid case issues
            
            // Conver the user input about taxpayer from y/n to boolean
            bool taxPayerBool = taxPayer == "y" ? true : false;

            // Ask User for total consumed units.
            Console.Write("Enter Total consumed units : ");
            int units = int.Parse(Console.ReadLine());

            //Now that we have all the necessary information, Let's create and initialize our class
            // Using a Factory Design Pattern to create the approrpriate consumer instance based on the consumer type.
            ConsumerBill consumer = ConsumerFactory.GetConsumer(consumerType, taxPayerBool, units);

            
            consumer.GetBill();
        }
    }
}