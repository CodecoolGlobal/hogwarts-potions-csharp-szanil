using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using HogwartsPotions.Models.Enums;

namespace HogwartsPotions.Models.Entities;

public class Potion
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID { get; set; }
    public string Name { get; set; }
    public Student Student { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BrewingStatus BrewingStatus { get; set; } = BrewingStatus.Brew;
    public Recipe Recipe { get; set; }
}