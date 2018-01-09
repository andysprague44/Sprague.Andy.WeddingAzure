using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprague.Andy.WeddingAzure.Models.Rsvp
{
    public class RsvpEntity : TableEntity
    {
        public RsvpEntity(string name)
        {
            this.PartitionKey = name.Substring(0,1).ToLower();
            this.RowKey = name;

            Name = name;
        }

        //Required for TableEntity
        public RsvpEntity() { }

        public string Name { get; set; }

        public bool AttendingWedding { get; set; }
        public bool AttendingPopInThePark { get; set; }
        public string DietaryRequirements { get; set; }
        public string SongRequest { get; set; }

    }
}
