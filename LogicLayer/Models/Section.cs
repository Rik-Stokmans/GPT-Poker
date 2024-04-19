using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicLayer.Models;

public class Section
{
    public Section(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Section(int id)
    {
        Id = id;
    }

    public Section()
    {
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

}