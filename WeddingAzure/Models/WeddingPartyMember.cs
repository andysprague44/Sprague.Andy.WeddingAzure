using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingAzure.Models
{
    public class WeddingPartyMember
    {
        public string ImageSrc { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public WeddingParty WeddingParty { get; set; }

        public WeddingPartyMember(
            string imageSrc,
            string name,
            string role,
            string description,
            WeddingParty weddingParty)
        {
            ImageSrc = imageSrc;
            Name = name;
            Role = role;
            Description = description;
            WeddingParty = weddingParty;
        }
    }

    public enum WeddingParty
    {
        Lizi,
        Andy,
    }
}