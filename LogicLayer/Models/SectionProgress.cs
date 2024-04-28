using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicLayer.Models;

public class SectionProgress
{
    public SectionProgress(int accountId, int sectionId, int unitProgress)
    {
        AccountId = accountId;
        SectionId = sectionId;
        UnitProgress = unitProgress;
    }

    public SectionProgress(int accountId = 0, int sectionId = 0)
    {
        AccountId = accountId;
        SectionId = sectionId;
    }

    public SectionProgress()
    {
    }
    
    [Key]
    public int AccountId { get; set; }
    
    [Key]
    public int SectionId { get; set; }
    
    public int UnitProgress { get; set; }
}