using LogicLayer.Models;

namespace GPT_Poker.Models;

public class AccountViewModel(Account account, List<Section> sections)
{
    public Account Account = account;

    public List<Section> Sections = sections;
}