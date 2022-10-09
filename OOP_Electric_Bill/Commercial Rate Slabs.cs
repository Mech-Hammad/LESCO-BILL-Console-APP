using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Electric_Bill
{
    // If we need to add any attributes specific only to Residential RateSlabs,
    // We can add them here in ResidentialRateSlab
    internal class CommercialRateSlab : BaseRateSlab
    {
    }

    //Now each slab has been created as a separate Class which is instantiated only when required.
    //If we need to add slab specific properties, we can add them in the residential slab classes below

    class CommercialUnitsUpto100 : CommercialRateSlab
    {
        public CommercialUnitsUpto100()
        {
            UnitRate = 8; //This UnitRate encapsulates the unitRate attribute inherited from BaseResidential Slab
        }

    }
    class CommercialUnits100to200 : CommercialRateSlab
    {
        public CommercialUnits100to200()
        {
            UnitRate = 21; //This UnitRate encapsulates the unitRate attribute inherited from BaseResidential Slab
        }

    }
    class CommercialUnits200to500 : CommercialRateSlab
    {
        public CommercialUnits200to500()
        {
            UnitRate = 23; //This UnitRate encapsulates the unitRate attribute inherited from BaseResidential Slab
        }

    }
    class CommercialUnitsOver500 : CommercialRateSlab
    {
        public CommercialUnitsOver500()
        {
            UnitRate = 79; //This UnitRate encapsulates the unitRate attribute inherited from BaseResidential Slab
        }

    }
}
