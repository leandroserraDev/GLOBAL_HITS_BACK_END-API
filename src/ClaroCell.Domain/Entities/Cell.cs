using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Domain.Entities
{
    public class Cell
    {
        public Cell(string model,
                    int price,
                    string brand,
                    string photo,
                    DateTime date)
        {
            Model = model;
            Price = price;
            Brand = brand;
            Photo = photo;
            Date = date;
            Code = Guid.NewGuid();
        }

        protected Cell() { }

        public int Id { get; set; }
        public Guid Code { get;  set; }
        public string Model { get;  set; }
        public int Price { get;  set; }
        public string Brand { get;  set; }
        public string Photo { get;  set; }

        public DateTime Date { get;  set; }


    }
}
