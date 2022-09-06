using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingApp.Enums;

namespace ParkingApp.Models
{
    
    public abstract class Park
    {
        private bool ParkSpotCheck = true;



        public static void ParkingSpot()
        {
            string[] ParkSpot = new string[19];


            for (int i=0; i <= ParkSpot.Length; i++)
            {
                Console.Write(i+1 + " ");
                if(i%4==3)
                    Console.WriteLine(" ");
                
            }

            Console.WriteLine("Please choose the spot that you want to park ");
            string parkSpotChoise = Console.ReadLine();
            int removeIndex = Array.IndexOf(ParkSpot, parkSpotChoise);
            ParkSpot[removeIndex] = " ";
            for (int i = 0; i <= ParkSpot.Length; i++)
            {
                Console.Write(i + 1 + " ");
                if (i % 4 == 3)
                    Console.WriteLine(" ");

            }

        }

  

    }

}
