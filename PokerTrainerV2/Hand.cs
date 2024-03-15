namespace PokerTrainerV2;

public class Hand
{
    public readonly List<Card> Cards;
    public bool IsSuited => Cards[0].Suit == Cards[1].Suit;
    public bool IsPair => Cards[0].Rank == Cards[1].Rank;

    public Hand()
    {
        var deck = new Deck();
        
        Cards = new List<Card> { deck.Draw(), deck.Draw() };
        
        Cards.Sort((a, b) => (int) b.Rank - (int) a.Rank);

        if (IsPair) return;
        if (!IsSuited) Cards.Reverse();
    }
    
    public Hand(Deck deck)
    {
        Cards = new List<Card> { deck.Draw(), deck.Draw() };
        
        Cards.Sort((a, b) => (int) b.Rank - (int) a.Rank);

        if (IsPair) return;
        if (!IsSuited) Cards.Reverse();
    }
    public Hand(List<Card> cards)
    {
        Cards = cards;
        Cards.Sort((a, b) => (int) b.Rank - (int) a.Rank);

        if (IsPair) return;
        if (!IsSuited) Cards.Reverse();
    }

    public string GetStringRepresentation()
    {
        return IsSuited
            ? Cards[0].GetStringRepresentation() + Cards[1].GetStringRepresentation() + (IsSuited ? "s" : "o")
            : Cards[1].GetStringRepresentation() + Cards[0].GetStringRepresentation() + (IsSuited ? "s" : "o");
    }
}