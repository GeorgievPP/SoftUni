using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Logger.Core.Contracts
{
    public interface IController
    {
        void Act(int countOfAppenders);
    }
}
