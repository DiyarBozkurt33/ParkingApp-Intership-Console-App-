using ParkingApp.Enums;

namespace ParkingApp.Models
{
    public class ComercialVehicle : BaseVehicleModel
    {

        public ComercialVehicle()
        {

        }

        public override int CalculateParkPrice(PeriodTypes period)
        {
            switch (period)
            {
                case PeriodTypes.Period1:
                    return 7;
                case PeriodTypes.Period2:
                    return 14;
                case PeriodTypes.Period3:
                    return 32;
                case PeriodTypes.Period4:
                    return 75;
                case PeriodTypes.Period5:
                    return (int)(75 + this.FloatTime * 25);
            }
            return 0;
        }
    }
}
