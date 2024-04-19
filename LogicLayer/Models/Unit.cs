using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicLayer.Models;

public class Unit
{
    public Unit(int id, int sectionId, int placeInSection, string name)
    {
        Id = id;
        SectionId = sectionId;
        PlaceInSection = placeInSection;
        Name = name;
    }

    public Unit(int id)
    {
        Id = id;
    }

    public Unit()
    {
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    public int SectionId { get; set; }
    
    public int PlaceInSection { get; set; }

    public string Name { get; set; } = null!;
}