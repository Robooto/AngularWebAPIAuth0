using System.Collections.Generic;

namespace ShipmentsAPI.Models
{
    public class Shipment
    {
        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public static List<Shipment> Create()
        {
            return new List<Shipment>
            {
                new Shipment
                {
                    Id = 123,
                    Destination = "Portland",
                    Origin = "Rainier Town"
                },
                new Shipment
                {
                    Id = 234,
                    Destination = "Pizza Ville",
                    Origin = "Portland"
                }
            };
        } 
    }
}