using ParkingApp.Enums;

namespace ParkingApp.Models
{
    public class Car : BaseVehicleModel
    {

        public Car()
        {

        }

        public override int CalculateParkPrice(PeriodTypes period)
        {

            switch (period)
            {
                case PeriodTypes.Period1: 
                    return 5;
                case PeriodTypes.Period2:
                    return 15;
                case PeriodTypes.Period3:
                    return 20;
                case PeriodTypes.Period4:
                    return 60;
                case PeriodTypes.Period5:
                    return  (int)(60 + (this.FloatTime * 10));
            }

            return 0;
        }
    }
}