using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components
            => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals
            => this.peripherals.AsReadOnly();

        public override double OverallPerformance 
            => this.Change(base.OverallPerformance);

        public override decimal Price 
            => base.Price + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);

        public void AddComponent(IComponent component)
        {
            if(this.components.FirstOrDefault(x => x.Id == component.Id) == component)
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.FirstOrDefault(x => x.Id == peripheral.Id) == peripheral)
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {

            if(!components.Any() || this.components.FirstOrDefault(x => x.GetType().Name == componentType) == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            var component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            this.components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!peripherals.Any() || this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType) == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            var peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");

            sb.AppendLine($" Components ({this.components.Count}):");
            if (this.components.Any())
            {
                foreach(var component in components)
                {
                    sb.AppendLine($"  {component.ToString()}");
                }
            }

           
            if (this.peripherals.Any())
            {
                sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(x => x.OverallPerformance):f2}):");
                foreach ( var peri in peripherals)
                {
                    sb.AppendLine($"  {peri.ToString()}");
                }
            }
            else
            {
                sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance (0.00):");
            }

            return sb.ToString().TrimEnd();
        }

        private double Change(double basePerf)
        {
            if (this.components.Any())
            {
                basePerf += this.components.Average(x => x.OverallPerformance);
            }

            return basePerf;
        }
    }
}
