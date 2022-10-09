using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Here by using an abtract base class, we can add as many rate slabs as required.
// If we need to add to add more properties to every rate slab, we can do that here.
//If in the future, new rate slabs are introduced, we can simply add new slabs here in this file.
namespace OOP_Electric_Bill
{
    internal abstract class BaseRateSlab
    {
        private double unitRate;

        public double UnitRate { get => unitRate; set => unitRate = value; }
    }

}
