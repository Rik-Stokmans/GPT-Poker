using System.Diagnostics;

namespace PokerTrainerV2.PreFlopTrainer;

public class PreFlopQuestion
{
    public Hand hand { get; }
    public TablePosition? position { get; }

    public PreFlopQuestion(Difficulty difficulty)
    {
        
        hand = new Hand();
        
        if (difficulty is Difficulty.Intermediate or Difficulty.Expert or Difficulty.Pro)
            position = (TablePosition) new Random().Next(5);
        else position = null;
        
        
        
    }
}


public enum Difficulty
 {
     Beginner,
     Intermediate,
     Expert,
     Pro
 }