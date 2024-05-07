using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicLayer.Models;

public class UnitProgress
{
    public UnitProgress(int accountId, int unitId, int lessonProgress, int sectionId)
    {
        AccountId = accountId;
        UnitId = unitId;
        LessonProgress = lessonProgress;
        SectionId = sectionId;
    }

    public UnitProgress(int accountId = 0, int unitId = 0)
    {
        AccountId = accountId;
        UnitId = unitId;
    }

    public UnitProgress()
    {
    }
    
    [Key]
    public int AccountId { get; set; }
    
    [Key]
    public int UnitId { get; set; }
    
    public int LessonProgress { get; set; }
    
    public int SectionId { get; set; }
}