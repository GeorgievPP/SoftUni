using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Input
{
    [XmlType("partId")]
    public class CarPartsInputModel
    {
        [XmlAttribute]
        public int Id { get; set; }
    }
}
