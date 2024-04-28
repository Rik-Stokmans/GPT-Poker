namespace LogicLayer.Models;

public class UnitProgress
{
    public UnitProgress(int accountId, int unitId)
    {
        AccountId = accountId;
        UnitId = unitId;
    }
    
    
    public int AccountId { get; set; }
    public int UnitId { get; set; }
}