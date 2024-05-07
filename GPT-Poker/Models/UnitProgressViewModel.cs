using LogicLayer.Models;

namespace GPT_Poker.Models;

public class UnitProgressViewModel(Unit unit, Dictionary<Lesson, LessonProgressEnum> lessonProgresses)
{
    public Unit Unit { get; set; } = unit;
    public Dictionary<Lesson, LessonProgressEnum> LessonProgresses { get; set; } = lessonProgresses;

}