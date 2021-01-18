using System;
using System.Collections;


namespace CustomRandomList
{

    public class RandomList : ArrayList
    {

        private Random random;

        public RandomList()
        { 
            this.random = new Random();
        }

        public int RandomInt()
        {
            return this.random.Next();
        }


        public int RandomString() =>  this.RandomInt();

    }
}
