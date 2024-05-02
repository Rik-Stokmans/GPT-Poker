using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    public static LessonProgress? GetLessonProgress(LessonProgress lessonProgress)
    {
        CheckInit();
        
        return _lessonProgressService.GetFromKey(lessonProgress).GetAwaiter().GetResult()?[0];
    }
    
    public static List<LessonProgress>? GetAllLessonsProgresses()
    {
        CheckInit();
        
        return _lessonProgressService.GetAll().GetAwaiter().GetResult();
    }
}