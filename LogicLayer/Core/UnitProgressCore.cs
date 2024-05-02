using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    public static List<UnitProgress>? GetAllAccountUnitProgresses(Account account)
    {
        CheckInit();
        
        return _unitProgressService.GetFromKey(new UnitProgress(accountId: account.Id)).GetAwaiter().GetResult();
    }
    
    public static List<UnitProgress>? GetAllUnitProgresses()
    {
        CheckInit();
        
        return _unitProgressService.GetAll().GetAwaiter().GetResult();
    }
}