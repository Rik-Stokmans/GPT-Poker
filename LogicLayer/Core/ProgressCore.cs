using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    public static List<SectionProgress>? GetAllAccountSectionProgresses(Account account)
    {
        CheckInit();
        
        return _sectionProgressService.GetFromKey(new SectionProgress(accountId: account.Id)).GetAwaiter().GetResult();
    }
    
    public static List<SectionProgress>? GetAllSectionProgresses()
    {
        CheckInit();
        
        return _sectionProgressService.GetAll().GetAwaiter().GetResult();
    }

    public static Progress GetSectionProgress(Account account, Section section)
    {
        Dictionary<Unit, Dictionary<Lesson, LessonProgressEnum>> progress = new ();

        var units = GetUnitsInSection(section);
        var lessonsProgress = _lessonProgressService.GetFromKey(new LessonProgress(accountId: account.Id)).GetAwaiter().GetResult();
        
        foreach (var unit in units)
        {
            var lessons = _lessonService.GetFromKey(new Lesson(unitId: unit.Id)).GetAwaiter().GetResult();
            
            Dictionary<Lesson, LessonProgressEnum> lessonProgresses = new ();
            
            foreach (var lesson in lessons)
            {
                var lessonProgress = lessonsProgress?.Find(x => x.LessonId == lesson.Id)?.Progress ?? LessonProgressEnum.NotStarted;
                lessonProgresses.Add(lesson, lessonProgress);
            }
            
            progress.Add(unit, lessonProgresses);
        }

        return new Progress(progress);
    }
}