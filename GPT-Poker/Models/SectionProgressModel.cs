using LogicLayer.Models;

namespace GPT_Poker.Models;

public class SectionProgressModel
{
    public int SectionId;
    public int UnitProgress;
    public int AccountId;
    public List<UnitProgressModel> unitProgressModels = [];
    
    public List<Section> Sections;
    
    public SectionProgressModel(SectionProgress sectionProgress, List<UnitProgress> unitProgresses, List<LessonProgress> lessonProgresses, List<Section> sections, List<Unit> units, List<Lesson> lessons)
    {
        SectionId = sectionProgress.SectionId;
        UnitProgress = sectionProgress.UnitProgress;
        AccountId = sectionProgress.AccountId;
        
        Sections = sections;
        
        foreach (var unitProgress in unitProgresses)
        {
            var unitProgressLessons = lessonProgresses.Where(x => x.UnitId == unitProgress.UnitId).ToList();
            
            unitProgressModels.Add(new UnitProgressModel(unitProgress, unitProgressLessons, units, lessons));
        }
    }

    
}