using LogicLayer.Models;
namespace GPT_Poker.Models;

public class SectionViewModel(Section section)
{
    
    //todo change to SectionViewModel that is specific to the progress of the player
    public Section Section = section;
}