﻿using ShowcaseRVHub.MAUI.Model.EnumTypes;

namespace ShowcaseRVHub.MAUI.Model
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public double Odometer { get; set; }
        public int GeneratorHours { get; set; }
        public FuelLevelType FuelLevel { get; set; }
        public string ExteriorDamage { get; set; }
        public string InteriorDamage { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; } = null;

        public BaseModel(
            int id, 
            DateTime createdOn, 
            double odometer, 
            int generatorHours, 
            FuelLevelType level, 
            string exteriorDamage, 
            string interiorDamage, 
            string notes, 
            int userId, 
            UserModel user)
        {
            Id = id;
            CreatedOn = createdOn;
            Odometer = odometer;
            GeneratorHours = generatorHours;
            FuelLevel = level;
            ExteriorDamage = exteriorDamage;
            InteriorDamage = interiorDamage;
            Notes = notes;
            UserId = userId;
            User = user;
        }
    }
}
