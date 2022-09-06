
using ParkingApp.Enums;
using ParkingApp.Models;
using ParkingApp.Services;
using System.Text.RegularExpressions;

internal class Program
{
    public static List<ParkSpot> ParkSpots;

    private static void Main(string[] args)
    {
        ParkService parkService = new ParkService();
        ParkSpots = parkService.CreateParkArea();
    Start:

        Console.WriteLine("Welcome please choose your vehicle type :)");
        Console.WriteLine("1. Car \r\n2. Long Vehicle \r\n3. Comercial Vehicle");
        string carInput = Console.ReadLine();
        var carInputInt = carInput;
        string carInputCheck = carInput;

        int moneyToPay = 0;
        var paymentAcceptReject = " ";

        
        if(carInputCheck == "1" || carInputCheck == "2"|| carInputCheck == "3")
        {
            Console.WriteLine("What is the time you will stay?");
            var timeInputString = Console.ReadLine();
            var timeInput = Convert.ToInt32(timeInputString);
            switch (carInputInt)
            {

                case "1":
                    Car car = new Car();
                    car.FloatTime = timeInput;
                    if (timeInput <= 1)
                    {
                        moneyToPay = car.CalculateParkPrice(PeriodTypes.Period1);

                    }
                    else if (timeInput <= 6)
                    {
                        moneyToPay = car.CalculateParkPrice(PeriodTypes.Period2);
                    }
                    else if (timeInput <= 12)
                    {
                        moneyToPay = car.CalculateParkPrice(PeriodTypes.Period3);
                    }
                    else if (timeInput <= 24)
                    {
                        moneyToPay = car.CalculateParkPrice(PeriodTypes.Period4);
                    }
                    else
                    {
                        moneyToPay = car.CalculateParkPrice(PeriodTypes.Period5);
                    }
                    break;

                case "2":
                    LongVehicle longVehicle = new LongVehicle();
                    longVehicle.FloatTime = timeInput;
                    if (timeInput <= 1)
                    {
                        moneyToPay = longVehicle.CalculateParkPrice(PeriodTypes.Period1);
                    }
                    else if (timeInput <= 6)
                    {
                        moneyToPay = longVehicle.CalculateParkPrice(PeriodTypes.Period2);
                    }
                    else if (timeInput <= 12)
                    {
                        moneyToPay = longVehicle.CalculateParkPrice(PeriodTypes.Period3);
                    }
                    else if (timeInput <= 24)
                    {
                        moneyToPay = longVehicle.CalculateParkPrice(PeriodTypes.Period4);
                    }
                    else
                    {
                        moneyToPay = longVehicle.CalculateParkPrice(PeriodTypes.Period5);
                    }
                    break;

                case "3":
                    ComercialVehicle comercialVehicle = new ComercialVehicle();
                    comercialVehicle.FloatTime = timeInput;
                    if (timeInput <= 1)
                    {
                        moneyToPay = comercialVehicle.CalculateParkPrice(PeriodTypes.Period1);
                    }
                    else if (timeInput <= 6)
                    {
                        moneyToPay = comercialVehicle.CalculateParkPrice(PeriodTypes.Period2);
                    }
                    else if (timeInput <= 12)
                    {
                        moneyToPay = comercialVehicle.CalculateParkPrice(PeriodTypes.Period3);
                    }
                    else if (timeInput <= 24)
                    {
                        moneyToPay = comercialVehicle.CalculateParkPrice(PeriodTypes.Period4);
                    }
                    else
                    {
                        moneyToPay = comercialVehicle.CalculateParkPrice(PeriodTypes.Period5);
                    }
                    break;                    
            }
        }

        else
        {
            Console.Clear();
            Console.WriteLine("The car type you entered is wrong be more careful");
            Console.WriteLine(new String('*',45));
            goto Start;
        }
           
        Console.WriteLine("You need to pay " + moneyToPay + " Turkish Lira");

    Start2:
        Console.WriteLine("Do you accept pay the price ?");
        Console.WriteLine("Pres 'y' to accept 'n' to reject");
        paymentAcceptReject = Console.ReadLine()!.ToLower();

        if (paymentAcceptReject == "y")
        {
            string CarPlate = string.Empty;
            bool isSuccess = false;
            int counter = 0;
            while (!isSuccess)
            {
                if (counter > 2)
                    goto Start;

                Console.WriteLine("Please enter your car plate. Right format NN SS NNN");
                CarPlate = Console.ReadLine()!;

                BaseVehicleModel.GetCarPlate(CarPlate!, out isSuccess);
                if (!isSuccess)
                {
                    Console.WriteLine($"You entered wrong car plate! Retry count {2 - counter}");
                    counter++;
                }
                else
                    break;
            }
            
            ParkSpots = parkService.DisplayParkArea(ParkSpots);
            goto Start;
        }

        else if (paymentAcceptReject == "n")
        {
            goto Start;
        }

        else
        {
            Console.WriteLine("You entered a wrong input");
            goto Start2;
           
        }


        Console.ReadKey();
    }

}