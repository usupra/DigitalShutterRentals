using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalShutterRentals
{
    public class Equipment
    {
        public string Id { get; set; }
        public string ModelName { get; set; }
        public string Category { get; set; }
        public decimal DailyRate { get; set; }
        public string OwnerUsername { get; set; }
        public bool IsAvailable { get; set; }

        public Equipment(string id, string modelName, string category, decimal dailyRate, string ownerUsername, bool isAvailable)
        {
            Id = id;
            ModelName = modelName;
            Category = category;
            DailyRate = dailyRate;
            OwnerUsername = ownerUsername;
            IsAvailable = isAvailable;
        }

        public string ToCsvLine()
        {
            return $"{Id},{ModelName},{Category},{DailyRate},{OwnerUsername},{IsAvailable}";
        }
    }
}
