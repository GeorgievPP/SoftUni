using System;

namespace P08.MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string DEF_EXE_MSG = "Mission already completed!";

        public InvalidMissionCompletionException()
            : base (DEF_EXE_MSG)
        {

        }

        public InvalidMissionCompletionException(string message) 
            : base(message)
        {

        }
    }
}
