using OnlineShop.Models.Products;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<Models.Products.Components.IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<Models.Products.Components.IComponent>();
            this.peripherals = new List<IPeripheral>();
        }


        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            if(computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            Models.Products.Components.IComponent component = null;

            switch (componentType)
            {
                case nameof(CentralProcessingUnit):
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(Motherboard):
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(PowerSupply):
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(RandomAccessMemory):
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(SolidStateDrive):
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case nameof(VideoCard):
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
            }

            if(component == null)
            {
                throw new ArgumentException("Component type is invalid.");
            }

            var component1 = this.components.FirstOrDefault(x => x.Id == component.Id);
            if(component1 != null)
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            computer.AddComponent(component);
            this.components.Add(component);

            return $"Component {component.GetType().Name} with id {component.Id} added successfully in computer with id {computer.Id}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = null;

            switch (computerType)
            {
                case nameof(DesktopComputer):
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case nameof(Laptop):
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
            }

            if(computer == null)
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            if(this.computers.Any() && this.computers.FirstOrDefault(x => x.Id == computer.Id) != null)
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            this.computers.Add(computer);

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IPeripheral peripheral = null;

            switch (peripheralType)
            {
                case nameof(Headset):
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(Keyboard):
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(Monitor):
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case nameof(Mouse):
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
            }

            if(peripheral == null)
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            var peripheral1 = this.peripherals.FirstOrDefault(x => x.Id == peripheral.Id);
            if(peripheral1 != null)
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return $"Peripheral {peripheral.GetType().Name} with id {peripheral.Id} added successfully in computer with id {computer.Id }.";
        }

        public string BuyBest(decimal budget)
        {
            if (!this.computers.Any())
            {
                throw new ArgumentException($" Can't buy a computer with a budget of ${budget}."); // tyka
            }

            var posta = this.computers.Where(x => x.Price <= budget).ToList();
            if (!posta.Any())
            {
                throw new ArgumentException($" Can't buy a computer with a budget of ${budget}."); // tyka
            }

            double overall = 0.0;

            foreach(var comp in posta)
            {
                if(comp.OverallPerformance >= overall)
                {
                    overall = comp.OverallPerformance;
                }
            }

            var computer = this.computers.FirstOrDefault(x => x.OverallPerformance == overall);

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == id);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == id);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            if(component == null)
            {
                return "Greshka";
            }

            computer.RemoveComponent(componentType);
            this.components.Remove(component);

            return $"Successfully removed {component.GetType().Name} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripheral == null)
            {
                return "Greshka";
            }

            computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }
    }
}
