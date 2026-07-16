using System;
using System.Linq;
using System.Collections.Generic;
namespace SalesWebMvc.Models
{
    public class Department
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {

        }
        public Department(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        } 
    }
}
