using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    // ReSharper disable once NullableWarningSuppressionIsUsed
    private static IDatabaseEntityService<Account> _accountService = null!;
    private static IDatabaseEntityService<Section> _sectionService = null!;
    private static IDatabaseEntityService<Unit> _unitService = null!;
    private static IDatabaseEntityService<Lesson> _lessonService = null!;
    private static IDatabaseEntityService<SectionProgress> _sectionProgressService = null!;
    private static IDatabaseEntityService<UnitProgress> _unitProgressService = null!;
    private static IDatabaseEntityService<LessonProgress> _lessonProgressService = null!;
    private static bool _initialized;
    

    public static void Init(IDatabaseEntityService<Account> accountService, IDatabaseEntityService<Section> sectionService, IDatabaseEntityService<Unit> unitService, IDatabaseEntityService<Lesson> lessonService, IDatabaseEntityService<SectionProgress> sectionProgressService, IDatabaseEntityService<UnitProgress> unitProgressService, IDatabaseEntityService<LessonProgress> lessonProgressService)
    {
        _accountService = accountService;
        _sectionService = sectionService;
        _unitService = unitService;
        _lessonService = lessonService;
        _sectionProgressService = sectionProgressService;
        _unitProgressService = unitProgressService;
        _lessonProgressService = lessonProgressService;
        _initialized = true;
    }
    
    
    
    //Private methods
    private static void CheckInit()
    {
        if (!_initialized) throw new Exception("Core not initialized");
    }
    
}