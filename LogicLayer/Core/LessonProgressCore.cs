using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    public static List<LessonProgress>? GetAllAccountLessonProgresses(Account account)
    {
        CheckInit();
        
        return _lessonProgressService.GetFromKey(new LessonProgress(accountId: account.Id)).GetAwaiter().GetResult();
    }
    
    public static List<LessonProgress>? GetAllLessonsProgresses()
    {
        CheckInit();
        
        return _lessonProgressService.GetAll().GetAwaiter().GetResult();
    }
}