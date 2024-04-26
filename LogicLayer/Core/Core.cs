using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    // ReSharper disable once NullableWarningSuppressionIsUsed
    private static IDatabaseEntityService<Account> _accountService = null!;
    private static IDatabaseEntityService<Section> _sectionService = null!;
    private static IDatabaseEntityService<Unit> _unitService = null!;
    private static bool _initialized;
    
    public static void Init(IDatabaseEntityService<Account> accountService, IDatabaseEntityService<Section> sectionService, IDatabaseEntityService<Unit> unitService)
    {
        _accountService = accountService;
        _sectionService = sectionService;
        _unitService = unitService;
        _initialized = true;
    }
    
    
    
    //Private methods
    private static void CheckInit()
    {
        if (!_initialized) throw new Exception("Core not initialized");
    }
    
}