using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class MeasurementUnit
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } // مثل: "pages", "minutes"

    public string DisplayName { get; set; }

    public string Symbol { get; set; }

    public UnitCategory Category { get; set; }

    public double ConversionFactorToBase { get; set; }

    public bool Default { get; set; }
}

