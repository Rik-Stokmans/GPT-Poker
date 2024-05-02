using LogicLayer.Models;

namespace GPT_Poker.Models;

public class LessonProgressModel(LessonProgress lessonProgress, List<Lesson> lessons)
{
    public int AccountId { get; set; } = lessonProgress.AccountId;
    public int LessonId { get; set; } = lessonProgress.LessonId;
    public int Progress { get; set; } = lessonProgress.Progress;
    public int UnitId { get; set; } = lessonProgress.UnitId;

    public List<Lesson> Lessons { get; set; } = lessons;
}