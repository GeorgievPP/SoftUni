using System;

namespace P08.MilitaryElite.Exceptions
{
    public class InvalidMissionStateException : Exception
    {
        private const string DEF_EXE_MSG = "Invalid mission state!";

        public InvalidMissionStateException()
            : base (DEF_EXE_MSG)
        {

        }

        public InvalidMissionStateException(string message) 
            : base(message)
        {

        }
    }
}
