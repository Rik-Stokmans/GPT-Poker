using LogicLayer.Core;
using LogicLayer.Models;

namespace GPT_Poker.Models;

public class AccountProgressModel
{
    public int AccountId;
    public string Username;
    public string Email;
    public int Lives;

    public List<Section> Sections;
    public List<Unit> Units;
    public List<Lesson> Lessons;
    
    public List<SectionProgressModel> sectionProgressModels = [];
    
    
    public AccountProgressModel(Account account, List<SectionProgress> sectionProgresses, List<UnitProgress> unitProgresses, List<LessonProgress> lessonProgresses, List<Section> sections, List<Unit> units, List<Lesson> lessons)
    {
        AccountId = account.Id;
        Username = account.Username;
        Email = account.Email;
        Lives = account.Lives;
        
        Sections = sections;
        Units = units;
        Lessons = lessons;
        
        foreach (var sectionProgress in sectionProgresses)
        {
            var sectionProgressUnits = unitProgresses.Where(x => x.SectionId == sectionProgress.SectionId).ToList();
            
            sectionProgressModels.Add(new SectionProgressModel(sectionProgress, sectionProgressUnits, lessonProgresses, sections, units, lessons));
        }
    }
}

