using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableNinja.Enumerations;
using VegetableNinja.Interfaces;
using VegetableNinja.Models;
using VegetableNinja.Models.Vegetables;

namespace VegetableNinja.Data
{
    public class Database : IDatabase
    {
        private List<INinja> ninjas;
        private List<IVegetable> vegetables;
        private List<List<IGameObject>> gameField;
        private List<IBlankSpace> growingVegetables;

        public Database()
        {
            this.ninjas = new List<INinja>();
            this.vegetables = new List<IVegetable>();
            this.gameField = new List<List<IGameObject>>();
            this.growingVegetables = new List<IBlankSpace>();
        }





        public IEnumerable<INinja> Ninjas => this.ninjas;

        public IEnumerable<IVegetable> Vegetables => this.vegetables;

        public IEnumerable<IBlankSpace> GrowingVegetables
        {
            get
            {
                this.growingVegetables.RemoveAll(veg => veg.GrowthTime <= 0);
                return this.growingVegetables;
            }
        }

        public IEnumerable<IEnumerable<IGameObject>> GameField => this.gameField;

        public void AddGrowingVegetable(IBlankSpace growingVegetable)
        {
            this.growingVegetables.Add(growingVegetable);
        }

        public void AddNinja(INinja ninja)
        {
            this.ninjas.Add(ninja);
        }

        public void AddVegetable(IVegetable vegetable)
        {
            this.vegetables.Add(vegetable);
        }

        public INinja GetOtherPlayer(string currentPlayerName)
        {
            return this.Ninjas.First(ninja => !ninja.Name.Equals(currentPlayerName));
        }

        public void RemoveVegetable(IVegetable vegetable)
        {
            this.vegetables.Remove(vegetable);
        }

        public void SeedField(IList<string> inputMatrix, string firstNinjaName, string secondNinjaName)
        {
            for(int i = 0; i < inputMatrix.Count; i++)
            {
                List<IGameObject> currentRow = new List<IGameObject>();

                string currentInputRow = inputMatrix[i];

                for(int j = 0; j < currentInputRow.Length; j++)
                {
                    char currentElement = currentInputRow[j];

                    IVegetable newVegetable = null;
                    IBlankSpace newBlanckSpace = null;
                    INinja newNinja = null;
                    IMatrixPosition position = new MatrixPosition(i, j);

                    switch (currentElement)
                    {
                        case 'A':
                            newVegetable = new Asparagus(position);
                            break;
                        case 'B':
                            newVegetable = new Broccoli(position);
                            break;
                        case 'C':
                            newVegetable = new CherryBerry(position);
                            break;
                        case 'M':
                            newVegetable = new Mushroom(position);
                            break;
                        case 'R':
                            newVegetable = new Royal(position);
                            break;
                        case '*':
                            newVegetable = new MeloLemonMelon(position);
                            break;
                        case '-':
                            newBlanckSpace = new BlankSpace(position, -1, VegetableType.Blank);
                            break;
                    }

                    if (currentElement.Equals(firstNinjaName[0]))
                    {
                        newNinja = new Ninja(position, firstNinjaName);
                    }

                    if (currentElement.Equals(secondNinjaName[0]))
                    {
                        newNinja = new Ninja(position, secondNinjaName);
                    }

                    if(newVegetable != null)
                    {
                        this.AddVegetable(newVegetable);
                        currentRow.Add(newVegetable);
                    }

                    if(newNinja != null)
                    {
                        this.AddNinja(newNinja);
                        currentRow.Add(newNinja);
                    }

                    if(newBlanckSpace != null)
                    {
                        currentRow.Add(newBlanckSpace);
                    }
                }

                this.gameField.Add(currentRow);
            }
        }

        public void SetGameFieldObject(IMatrixPosition position, IGameObject gameObject)
        {
            this.gameField[position.PositionX][position.PositionY] = gameObject;
        }
    }
}
