using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableNinja.Exceptions;
using VegetableNinja.Interfaces;

namespace VegetableNinja.Models
{
    public class MatrixPosition : IMatrixPosition
    {
        private int positionX;
        private int positionY;

        public MatrixPosition(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
        }

        public int PositionX
        {
            get => this.positionX;
            protected set
            {
                if(value < 0)
                {
                    throw new PotatoException("You are patato.");
                }

                this.positionX = value;
            }
        }

        public int PositionY
        {
            get => this.positionY;
            protected set
            {
                if (value < 0)
                {
                    throw new PotatoException("You are patato.");
                }

                this.positionY = value;
            }
        }

        public bool Equals(IMatrixPosition other)
        {
            return this.PositionX == other.PositionX && this.PositionY == other.PositionY;
        }
    }
}
