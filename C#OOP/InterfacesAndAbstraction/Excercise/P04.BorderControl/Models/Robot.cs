using P04.BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.BorderControl.Models
{
    public class Robot : IRobot,IIdentifable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; }

        public string Id { get; }
    }
}
