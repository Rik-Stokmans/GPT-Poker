using LogicLayer.Models;

namespace GPT_Poker.Models;

public class UnitProgressModel
{
    public int UnitId;
    public int SectionId;
    public int AccountId;
    public int LessonProgress;
    
    public List<Unit> Units;
    
    public List<LessonProgressModel> lessonProgressModels = [];
    
    public UnitProgressModel(UnitProgress unitProgress, List<LessonProgress> lessonProgresses, List<Unit> units, List<Lesson> lessons)
    {
        UnitId = unitProgress.UnitId;
        SectionId = unitProgress.SectionId;
        AccountId = unitProgress.AccountId;
        LessonProgress = unitProgress.LessonProgress;

        Units = units;
        
        
        foreach (var lessonProgress in lessonProgresses)
        {
            lessonProgressModels.Add(new LessonProgressModel(lessonProgress, lessons));
        }
    }
}