﻿namespace Domain.Entities.HabitModels
{
    public class HabitLog
    {
        public DateTime Date { get; set; }
        public bool Completed { get; set; }
        public int? Amount { get; set; }
        public string? MeasurementUnitId { get; set; }
    }
}
