using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    public static Unit? GetUnit(Unit unit)
    {
        CheckInit();
        
        return _unitService.GetFromKey(unit).GetAwaiter().GetResult();
    }
    
    public static List<Unit>? GetAllUnits()
    {
        CheckInit();
        
        return _unitService.GetAll().GetAwaiter().GetResult();
    }
}