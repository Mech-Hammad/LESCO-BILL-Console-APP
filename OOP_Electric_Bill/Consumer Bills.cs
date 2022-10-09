using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Electric_Bill
{
    
    internal abstract class ConsumerBill
    {
        protected bool taxPayer = false; // Non Taxpayers by Default
        private int unitsConsumed = 0; // 0 by default
        protected double taxRate = 10; // 10% by default


        public bool TaxPayer { get { return taxPayer; } set { taxPayer = value; } }

        public int UnitsConsumed { get => unitsConsumed; set => unitsConsumed = value; }
        public double TaxRate { get => taxRate; set => taxRate = value; }

        public abstract double GetBill();

        protected virtual double ApplyTax(double bill) // This takes the calculated bill and applies tax on top
        {
            double tax = bill * TaxRate / 100;
            Console.WriteLine("Tax on {0} units at {1}% = {2}", bill, TaxRate, tax);
            return bill + tax;
        }

        protected virtual double SlabBill(BaseRateSlab slabLower, BaseRateSlab slabMain, int slabFloor) // Calculates bill based on slabs
        {
            double bill1 = slabLower.UnitRate * slabFloor;
            double bill2 = slabMain.UnitRate * (UnitsConsumed - slabFloor);
            double totalBill = bill1 + bill2;
            Console.WriteLine("Unit Rate Upto {0}: Rs:{1}", slabFloor, slabLower.UnitRate);
            Console.WriteLine("Bill Upto {0} units: Rs:{1}", slabFloor, bill1);
            Console.WriteLine("Unit Rate Above {0}: Rs:{1}", slabFloor, slabMain.UnitRate);
            Console.WriteLine("Bill of {0} units above {1} units: Rs:{2}", UnitsConsumed - slabFloor, slabFloor, bill2);
            Console.WriteLine("Bill = {0}", totalBill);


            return totalBill;
        }

    }

    internal class CommercialBill : ConsumerBill // Consumer is Base Class
    {
        public CommercialBill(bool ataxPayer, int units)
        {
            TaxRate = 17; //17% for commercial
            TaxPayer = ataxPayer;
            UnitsConsumed = units;

        }

        public override double GetBill()
        {
            double currentBill = ApplyTax(CalculateBill());
            Console.WriteLine("Current Bill: {0}", currentBill);
            return currentBill;
        }
        private double CalculateBill()
        {
            if (UnitsConsumed <= 100) // less than 100
            {
                return SlabBill(new CommercialUnitsUpto100(), new CommercialUnitsUpto100(), 0);
            }
            else if (UnitsConsumed <= 200) // 100 to 200
            {
                return SlabBill(new CommercialUnitsUpto100(), new CommercialUnits100to200(), 100);
            }
            else if (UnitsConsumed <= 500) // 200 to 500
            {
                if (TaxPayer) // in case of tax payer, use Lower Slab for all units
                {
                    Console.WriteLine("You're getting slab benefit for being a tax payer");
                    return SlabBill(new CommercialUnits100to200(), new CommercialUnits100to200(), 200);
                }

                else
                    return SlabBill(new CommercialUnits100to200(), new CommercialUnits200to500(), 200);
            }
            else if (UnitsConsumed > 500) // Over 500
            {
                return SlabBill(new CommercialUnits200to500(), new CommercialUnitsOver500(), 500);
            }

            return 0; // in case the units are 0;
        }
    }

    internal class ResendentialBill : ConsumerBill// Consumer is Base Class
    {
        public ResendentialBill(bool ataxPayer, int units) //Constructor
        {
            TaxRate = 13;// 13% for resendential
            TaxPayer = ataxPayer;
            UnitsConsumed = units;
        }

        public override double GetBill()
        {
            double currentBill = ApplyTax(CalculateBill());
            Console.WriteLine("Current Bill: {0}", currentBill);
            return currentBill;
        }

        private double CalculateBill()
        {
            if (UnitsConsumed <= 100) // less than 100
            {
                return SlabBill(new ResidentialUnitsUpto100(), new ResidentialUnitsUpto100(), 0);
            }
            else if (UnitsConsumed <= 200) // 100 to 200
            {
                return SlabBill(new ResidentialUnitsUpto100(), new ResidentialUnits100to200(), 100);
            }
            else if (UnitsConsumed <= 500) // 200 to 500
            {
                if (TaxPayer) // in case of tax payer, use Lower Slab for all units
                {
                    Console.WriteLine("You're getting slab benefit for being a tax payer");
                    return SlabBill(new ResidentialUnits100to200(), new ResidentialUnits100to200(), 200);
                }

                else
                    return SlabBill(new ResidentialUnits100to200(), new ResidentialUnits200to500(), 200);
            }
            else if (UnitsConsumed > 500) // Over 500
            {
                return SlabBill(new ResidentialUnits200to500(), new ResidentialUnitsOver500(), 500);
            }

            return 0; // in case the units are 0;
        }

    }
}
