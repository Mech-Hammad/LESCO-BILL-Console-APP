using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Electric_Bill
{
    //Purpose of this factory class is to create our required class using the required parameters.
    //If we add more types of bills as such industry bill we will add the necessary code here.
    static internal class ConsumerFactory
    {
        static public ConsumerBill GetConsumer(string type, bool ataxPayer, int units)
        {
            if (type == "r") // Resendential
            {
                ConsumerBill consumer = new ResendentialBill(ataxPayer, units);
                return consumer;
            }
                
            else if (type == "c") // Commercial
            {
                ConsumerBill consumer = new CommercialBill(ataxPayer, units);
                return consumer;
            }

            return null;

        }
    }
}
