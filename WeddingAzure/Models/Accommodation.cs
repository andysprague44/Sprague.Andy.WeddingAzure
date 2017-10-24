using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingAzure.Models
{
    public class Accommodation
    {
        public string Name { get; set; }
        public string Address  { get; set; }
        public string Phone  { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public Accommodation(
            string name,
            string address,
            string phone,
            string description,
            string link)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Description = description;
            Link = link;
        }
    }
}