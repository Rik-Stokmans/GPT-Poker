using LogicLayer.Models;
namespace GPT_Poker.Models;

public class SectionViewModel(Section section, Progress progress)
{
    public Section Section = section;
    public Progress Progress = progress;
}