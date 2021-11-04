using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var softUniContext = new SoftUniContext();
            var result = GetDepartmentsWithMoreThan5Employees(softUniContext);
            Console.WriteLine(result);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                                .Include(x => x.Addresses)
                                .FirstOrDefault(x => x.Name == "Seattle");
            
            var allAddressIds = town.Addresses.Select(x => x.AddressId).ToList();

            var employees = context.Employees
                                        .Where(x => x.AddressId.HasValue && allAddressIds.Contains(x.AddressId.Value))
                                        .ToList();
        
            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            //context.SaveChanges();

            foreach (var addressId in allAddressIds)
            {
                var address = context.Addresses.FirstOrDefault(x => x.AddressId == addressId);

                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{allAddressIds.Count} addresses in Seattle were deleted";
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                                    .Where(x => EF.Functions.Like(x.FirstName, "sa%"))
                                    .Select(x => new
                                    {
                                        x.FirstName,
                                        x.LastName,
                                        x.JobTitle,
                                        x.Salary
                                    })
                                    .OrderBy(x => x.FirstName)
                                    .ThenBy(x => x.LastName)
                                    .ToList();


            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                                    .Where(x => departments.Contains(x.Department.Name))
                                    .OrderBy(x => x.FirstName)
                                    .ThenBy(x => x.LastName)
                                    .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departaments = context.Departments
                                        .Where(x => x.Employees.Count > 5)
                                        .OrderBy(x => x.Employees.Count)
                                        .ThenBy(x => x.Name)
                                        .Select(x => new
                                        {
                                            x.Name,
                                            x.Manager.FirstName,
                                            x.Manager.LastName,
                                            Employees = x.Employees.Select(e => new
                                            {
                                                e.FirstName,
                                                e.LastName,
                                                e.JobTitle
                                            })
                                            .OrderBy(x => x.FirstName)
                                            .ThenBy(x => x.LastName)
                                            .ToList()
                                        })
                                        .ToList();

            var sb = new StringBuilder();

            foreach (var dep in departaments)
            {
                sb.AppendLine($"{dep.Name} - {dep.FirstName} {dep.LastName}");

                foreach (var emp in dep.Employees)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                                    .Select(x => new
                                    {
                                        x.AddressText,
                                        x.Town.Name,
                                        x.Employees.Count
                                    })
                                    .OrderByDescending(x => x.Count)
                                    .ThenBy(x => x.Name)
                                    .ThenBy(x => x.AddressText)
                                    .Take(10)
                                    .ToList();

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                                       .Include(x => x.EmployeesProjects)
                                       .ThenInclude(x => x.Project)
                                       .ToList()
                                       .Select(x => new
                                       {
                                           x.EmployeeId,
                                           x.FirstName,
                                           x.LastName,
                                           x.JobTitle,
                                           Projects = x.EmployeesProjects.Select(p => new
                                           {
                                               p.Project.Name
                                           })
                                           .OrderBy(x => x.Name)
                                       })
                                       .FirstOrDefault(x => x.EmployeeId == 147);

            var sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.Projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();

                                        
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                                    .Include(x => x.EmployeesProjects)
                                    .ThenInclude(x => x.Project)
                                    .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 &&
                                                                        p.Project.StartDate.Year <= 2003))
                                    .Select(x => new
                                    {
                                        EmployeeFirstName = x.FirstName,
                                        EmployeeLastName = x.LastName,
                                        ManegerFirsName = x.Manager.FirstName,
                                        ManegerLastName = x.Manager.LastName,
                                        Projects = x.EmployeesProjects.Select(p => new
                                        {
                                            ProjectName = p.Project.Name,
                                            StartDate = p.Project.StartDate,
                                            EndDate = p.Project.EndDate
                                        })
                                    })
                                    .Take(10)
                                    .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - Manager: {employee.ManegerFirsName} {employee.ManegerLastName}");

                foreach (var project in employee.Projects)
                {
                    var endDate = project.EndDate.HasValue 
                                    ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) 
                                    : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");

                }
            }
            var result = sb.ToString().TrimEnd();
            return result;

        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            var nakov = context.Employees
                               .FirstOrDefault(x => x.LastName == "Nakov");

            nakov.AddressId = address.AddressId;

            context.SaveChanges();

            var addresses = context.Employees
                                    .Select(x => new
                                    {
                                        x.Address.AddressText,
                                        x.Address.AddressId
                                    })
                                    .OrderByDescending(x => x.AddressId)
                                    .Take(10)
                                    .ToList();

            var sb = new StringBuilder();
            foreach (var employeeAddress in addresses)
            {
                sb.AppendLine(employeeAddress.AddressText);
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                                   .Where(x => x.Department.Name == "Research and Development")
                                   .Select(x => new
                                   {
                                       x.FirstName,
                                       x.LastName,
                                       x.Salary,
                                       DepartmentName = x.Department.Name,
                                   })
                                   .OrderBy(x => x.Salary)
                                   .ThenByDescending(x => x.FirstName)
                                   .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                                   .Where(x => x.Salary > 50_000)
                                   .Select(x => new
                                   {
                                       x.FirstName,
                                       x.Salary
                                   })
                                   .OrderBy(x => x.FirstName)
                                   .ToList();

            var sb = new StringBuilder();

            foreach(var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            var resulst = sb.ToString().TrimEnd();

            return resulst;

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                                   .Select(x => new
                                   {
                                       x.EmployeeId,
                                       x.FirstName,
                                       x.LastName,
                                       x.MiddleName,
                                       x.JobTitle,
                                       x.Salary
                                   })
                                   .OrderBy(x => x.EmployeeId)
                                   .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }

}
