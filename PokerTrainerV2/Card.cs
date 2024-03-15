namespace PokerTrainerV2;

public class Card(Card.CardSuit suit, Card.CardRank rank)
{
    public CardSuit Suit = suit;
    public CardRank Rank = rank;

    public enum CardSuit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum CardRank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
    
    public string GetStringRepresentation()
    {
        switch (Rank)
        {
            case CardRank.Ace:
                return "A";
            case CardRank.Two:
                return "2";
            case CardRank.Three:
                return "3";
            case CardRank.Four:
                return "4";
            case CardRank.Five:
                return "5";
            case CardRank.Six:
                return "6";
            case CardRank.Seven:
                return "7";
            case CardRank.Eight:
                return "8";
            case CardRank.Nine:
                return "9";
            case CardRank.Ten:
                return "T";
            case CardRank.King:
                return "K";
            case CardRank.Queen:
                return "Q";
            case CardRank.Jack:
                return "J";
        }
        return "";
    }
}