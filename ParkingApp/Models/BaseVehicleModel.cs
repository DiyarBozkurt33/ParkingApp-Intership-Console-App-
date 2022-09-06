using ParkingApp.Enums;
using System.Text.RegularExpressions;

namespace ParkingApp.Models
{
    public abstract class BaseVehicleModel
    {
        private float _floatTime;
        public float FloatTime
        {
            get
            {
                return _floatTime;
            }
            set
            {
                float overDayTime = ((value - 24) / 12);
                overDayTime = MathF.Ceiling(overDayTime);
                _floatTime = overDayTime;
            }
        }

        public static void GetCarPlate(string CarPlate, out bool success)
        {
            string[] modifiedCarPlate = new string[3];

            if (CarPlate.Length == 7)
            {
                modifiedCarPlate[0] = CarPlate.Substring(0, 2);
                modifiedCarPlate[1] = CarPlate.Substring(2, 2);
                modifiedCarPlate[2] = CarPlate.Substring(4, 3);

                for (int i = 0; i < modifiedCarPlate.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        int checkInt;
                        bool isNumber = int.TryParse(modifiedCarPlate[i], out checkInt);
                        if (isNumber == false)
                        {
                            success = false;
                            return;
                        }
                    }
                    else
                    {
                        bool isString = modifiedCarPlate[i].All(Char.IsLetter);
                        if (isString == false)
                        {
                            success=false;
                            return;
                        }
                    }
                }

                success = true;
                return;
            }
            else
            {
                success = false;
                return;
            }
        }
        abstract public int CalculateParkPrice(PeriodTypes type);
    }
}

