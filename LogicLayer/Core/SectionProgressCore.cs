using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    public static SectionProgress? GetSectionProgress(SectionProgress sectionProgress)
    {
        CheckInit();
        
        return _sectionProgressService.GetFromKey(sectionProgress).GetAwaiter().GetResult()?[0];
    }
    
    public static List<SectionProgress>? GetAllSectionProgresses()
    {
        CheckInit();
        
        return _sectionProgressService.GetAll().GetAwaiter().GetResult();
    }
}