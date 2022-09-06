using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Services
{
    public class ParkService
    {
        public ParkService()
        {

        }
        public List<ParkSpot> CreateParkArea ()
        {
            List<ParkSpot> parkSpots = new List<ParkSpot>();
            for (int i = 0; i < 20; i++)
            {
                ParkSpot parkSpot = new();
                parkSpot.Number = i+1;
                parkSpot.IsEmpty = true;
                parkSpots.Add(parkSpot);    
            }
            return parkSpots;

        }

        public List<ParkSpot> DisplayParkArea(List<ParkSpot> spots)
        {
            for (int i = 0; i < spots.Count ; i++)
            {
                if (spots[i].IsEmpty)
                    Console.Write(spots[i].Number + " ");
                else
                    Console.Write("  ");

                if (i % 4 == 3)
                    Console.WriteLine(" ");
            }
            Start4:
            Console.WriteLine("Please choose the spot that you want to park ");
            int parkSpotChoise = Convert.ToInt32(Console.ReadLine());
            if (parkSpotChoise > 21 || parkSpotChoise < 1)
            {
                Console.WriteLine("You choose a wrong spot number. Be more careful");
                goto Start4;
            }

            //string parkSpotString = parkSpotChoise.ToString();

            var removePark = spots.FirstOrDefault(x => x.Number == parkSpotChoise);
           
            if(removePark.IsEmpty != false)
            {
                removePark!.IsEmpty = false;
                for (int i = 0; i < spots.Count; i++)
                {
                    if (spots[i].IsEmpty)
                        Console.Write(spots[i].Number + " ");
                    else
                        Console.Write("  ");

                    if (i % 4 == 3)
                        Console.WriteLine(" ");
                }

                removePark!.IsEmpty = false;
            }
            else
            {
                Console.WriteLine("You entered a selected place");
                goto Start4;
            }
            
            return spots;
        }

    }
}
