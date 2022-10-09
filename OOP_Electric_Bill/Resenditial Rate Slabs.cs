using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Electric_Bill
{
    // If we need to add any attributes specific only to Residential RateSlabs,
    // We can add them here in ResidentialRateSlab
    internal class ResidentialRateSlab : BaseRateSlab
    {
    }

    //Now each slab has been created as a separate Class which is instantiated only when required.
    //If we need to add slab specific properties, we can add them in the residential slab classes below
    class ResidentialUnitsUpto100 : ResidentialRateSlab
    {
        public ResidentialUnitsUpto100()
        {
            UnitRate = 5; //This UnitRate encapsulates the unitRate attribute inherited from BaseResidential Slab
        }

    }
    class ResidentialUnits100to200 : ResidentialRateSlab
    {
        public ResidentialUnits100to200()
        {
            UnitRate = 17; //This UnitRate encapsulates the unitRate attribute inherited from BaseResidential Slab
        }

    }
    class ResidentialUnits200to500 : ResidentialRateSlab
    {
        public ResidentialUnits200to500()
        {
            UnitRate = 23; //This UnitRate encapsulates the unitRate attribute inherited from BaseResidential Slab
        }

    }
    class ResidentialUnitsOver500 : ResidentialRateSlab
    {
        public ResidentialUnitsOver500()
        {
            UnitRate = 69; //This UnitRate encapsulates the unitRate attribute inherited from BaseResidential Slab
        }

    }
}
