using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        

        //Method
        public int HoldValue { get; private set; } //to store the value gotten from rolling the dice

        public int Roll()
        {
            Random rand = new Random();
            //create a random number between 1 and 6 then stores it in holdValue
            HoldValue = rand.Next(1, 7); 
            
            return HoldValue;
        }


    }
}
