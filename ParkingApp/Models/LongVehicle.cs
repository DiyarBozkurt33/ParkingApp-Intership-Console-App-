using ParkingApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class LongVehicle : BaseVehicleModel
    {

        public LongVehicle()
        {

        }

        public override int CalculateParkPrice(PeriodTypes type)
        {
            switch (type)
            {
                case PeriodTypes.Period1:
                    return 10;
                case PeriodTypes.Period2:
                    return 25;
                case PeriodTypes.Period3:
                    return 40;
                case PeriodTypes.Period4:
                    return 80;
                case PeriodTypes.Period5:
                    return (int)(80 + this.FloatTime * 30);
            }
            return 0;
        }
    }
}
