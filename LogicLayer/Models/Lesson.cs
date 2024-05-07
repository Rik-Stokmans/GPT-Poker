using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicLayer.Models;

public class Lesson
{
    public Lesson(int id, int sectionId, int unitId, int placeInUnit, string name)
    {
        Id = id;
        SectionId = sectionId;
        UnitId = unitId;
        PlaceInUnit = placeInUnit;
        Name = name;
    }

    public Lesson(int id = 0, int unitId = 0, string? name = null)
    {
        Id = id;
        UnitId = unitId;
        if (name != null) Name = name;
    }

    public Lesson()
    {
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    public int SectionId { get; set; }

    [Key]
    public int UnitId { get; set; }
    
    public int PlaceInUnit { get; set; }

    [Key]
    public string Name { get; set; } = null!;
}