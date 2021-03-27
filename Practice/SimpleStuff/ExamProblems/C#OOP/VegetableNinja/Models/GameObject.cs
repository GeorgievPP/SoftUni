using VegetableNinja.Interfaces;

namespace VegetableNinja.Models
{
    public abstract class GameObject : IGameObject
    {
        private IMatrixPosition position;
        private char charValue;

        protected GameObject(IMatrixPosition position, char charValue)
        {
            this.Position = position;
            this.CharValue = charValue;
        }

        public IMatrixPosition Position
        {
            get => this.position;
            protected set
            {
                this.position = value;
            }
        }

        public char CharValue
        {
            get => this.charValue;
            protected set
            {
                this.charValue = value;
            }
        }
    }
}
