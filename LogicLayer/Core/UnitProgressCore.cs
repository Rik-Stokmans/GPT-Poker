using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    public static UnitProgress? GetUnitProgress(UnitProgress unitProgress)
    {
        CheckInit();
        
        return _unitProgressService.GetFromKey(unitProgress).GetAwaiter().GetResult()?[0];
    }
    
    public static List<UnitProgress>? GetAllUnitProgresses()
    {
        CheckInit();
        
        return _unitProgressService.GetAll().GetAwaiter().GetResult();
    }
}