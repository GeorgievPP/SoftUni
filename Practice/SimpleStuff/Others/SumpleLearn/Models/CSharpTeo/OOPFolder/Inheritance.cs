using System;
using System.Collections.Generic;
using System.Text;

namespace LToWEnAndTP.Models.CSharpTeo.OOPFolder
{
    public class Inheritance
    {
        public string Info()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inheritance is one of the fundamental attributes of object-oriented programming. " +
                "It allows you to define a child class that reuses (inherits), extends, or modifies the behavior of a parent class." +
                " The class whose members are inherited is called the base class." +
                " The class that inherits the members of the base class is called the derived class.");

            sb.AppendLine(new string('-', 15));

            sb.AppendLine("C# and .NET support single inheritance only. That is, a class can only inherit from a single class. " +
                "However, inheritance is transitive, which allows you to define an inheritance hierarchy for a set of types." +
                " In other words, type D can inherit from type C, which inherits from type B, which inherits from the base class type A. " +
                "Because inheritance is transitive, the members of type A are available to type D.");

            sb.AppendLine(new string('-', 15));

            return sb.ToString().TrimEnd();
        }

        public string ExtendInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Not all members of a base class are inherited by derived classes. The following members are not inherited:");

            sb.AppendLine("     Static constructors, which initialize the static data of a class.");
            sb.AppendLine("     Instance constructors, which you call to create a new instance of the class." +
                " Each class must define its own constructors.");
            sb.AppendLine("     Finalizers, which are called by the runtime's garbage collector to destroy instances of a class.");

            sb.AppendLine(new string('-', 55));

            sb.AppendLine("While all other members of a base class are inherited by derived classes, " +
                "whether they are visible or not depends on their accessibility. " +
                "A member's accessibility affects its visibility for derived classes as follows:");
            sb.AppendLine(new string('-', 15));
            sb.AppendLine("     Private members are visible only in derived classes that are nested in their base class. " +
                "Otherwise, they are not visible in derived classes.");
            sb.AppendLine(new string('-', 15));
            sb.AppendLine("     Protected members are visible only in derived classes.");
            sb.AppendLine(new string('-', 15));
            sb.AppendLine("     Internal members are visible only in derived classes that are located in the same assembly as the base class." +
                " They are not visible in derived classes located in a different assembly from the base class.");
            sb.AppendLine(new string('-', 15));
            sb.AppendLine("     Public members are visible in derived classes and are part of the derived class' public interface. " +
                "Public inherited members can be called just as if they are defined in the derived class.");

            return sb.ToString().TrimEnd();

        }
    }
}
