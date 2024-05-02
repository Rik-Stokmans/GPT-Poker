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
}