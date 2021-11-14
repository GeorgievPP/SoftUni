using CarDealer.Data;
using CarDealer.DataTransferObjects.Input;
using CarDealer.Models;
using CarDealer.XmlHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var supplierXml = File.ReadAllText("./Datesets/suppliers.xml");
            var partsXml = File.ReadAllText("./Datesets/parts.xml");
            var cartsXml = File.ReadAllText("./Datesets/cars.xml");



            ImportSuppliers(context, supplierXml);
            ImportParts(context, partsXml);
            var result = ImportCars(context, cartsXml);


            Console.WriteLine(result);
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";

            var cars = new List<Car>();

            var carsDtos = XmlConverter.Deserializer<CarInputModel>(inputXml, root);
            var allParts = context.Parts.Select(x => x.Id).ToList();

            foreach (var currentCar in carsDtos)
            {
                var distinctedParts = currentCar.CarPartsInputModel.Select(x => x.Id).Distinct();
                var parts = distinctedParts.Intersect(allParts);

                var car = new Car
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TravelledDistance = currentCar.TraveledDistance,
                };

                foreach (var part in parts)
                {
                    var partCar = new PartCar
                    {
                        PartId = part
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string root = "Parts";

            var parstDto = XmlConverter.Deserializer<PartInputModel>(inputXml, root);

            /*
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute(root));
            var textReader = new StringReader(inputXml);
            var partInputModels = xmlSerializer.Deserialize(textReader) as PartInputModel[];
            */
            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = parstDto
                .Where(s => supplierIds.Contains(s.SupplierId))
                .Select(x => new Part
            {
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                SupplierId = x.SupplierId
            }).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string root = "Suppliers";

            var suppliersDto = XmlConverter.Deserializer<SupplierInputModel>(inputXml, root);

            /*
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute(root));
            var textRead = new StringReader(inputXml);

            var suppliersDto = xmlSerializer.Deserialize(textRead) as SupplierInputModel[];
            */

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            }).ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
    }
}