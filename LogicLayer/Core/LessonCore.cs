using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    public static Lesson? GetLesson(Lesson lesson)
    {
        CheckInit();
        
        return _lessonService.GetFromKey(lesson).GetAwaiter().GetResult()?[0];
    }
    
    public static List<Lesson>? GetAllLessons()
    {
        CheckInit();
        
        return _lessonService.GetAll().GetAwaiter().GetResult();
    }
}