﻿using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                this.name = value;
            }
        }

        

        public int BulletsCount
        {
            get { return this.bulletsCount; }
            protected set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }

                this.bulletsCount = value;
            }
        }

        abstract protected int FireRate { get; }

        public  int Fire()
        {
            if(BulletsCount - FireRate >= 0)
            {
                BulletsCount -= FireRate;
                return FireRate;
            }
            else
            {
                int resultingBullets = BulletsCount;
                BulletsCount = 0;
                return resultingBullets;
            }
        }
       
    }
}
