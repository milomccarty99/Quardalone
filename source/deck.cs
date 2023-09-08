using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

public class Deck
{
  private int length;
  private int handSize;
  private List<XmlNode> deck;
  private List<XmlNode> hand;
  private List<XmlNode> discard;
  private List<XmlNode> sideboard;
  private List<XmlNode> graveyard;
  private static Random rand = new Random(42);

  public Deck(List<XmlNode> startingDeck)
  {
    this.length = startingDeck.Count;
    this.handSize = 5;
    this.deck = startingDeck;
    this.hand = new List<XmlNode>();

  }

  //Fisher-Yates shuffle
  public void ShuffleDeck()
  {
    int n = deck.Count;
    while (n > 1) {
      n--;
      int k = rand.Next(n+1);
      XmlNode card = deck[k];
      deck[k] = deck[n];
      deck[n] = card;
    }
  }


  public XmlNode DrawTop()
  {
    if (deck.Count > 0){
      XmlNode result = deck[0];
      deck.RemoveAt(0);
      return result;
    }
    else {
      return null;
    }
  }
  public void DrawOneFreeform()
  {
    if (hand == null) {
      hand = new List<XmlNode>();
    }

  }
  public List<XmlNode> GetDeck()
  {
    return this.deck;
  }

  public List<XmlNode> GetHand()
  {
    return this.hand;
  }
}
