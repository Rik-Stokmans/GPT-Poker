namespace LogicLayer.Models;

public class Progress(Dictionary<Unit, Dictionary<Lesson, LessonProgressEnum>> progress)
{
    public Dictionary<Unit, Dictionary<Lesson, LessonProgressEnum>> SectionProgress = progress;
}