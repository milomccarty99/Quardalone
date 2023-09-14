using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

class MainLoop {
  public static Random rng = new Random();

  public static int Main() {

    XmlDocument doc = new XmlDocument();
    doc.Load("data/cards.xml");
    String dataPath = Console.ReadLine();
    if (dataPath.Length > 0) {
      doc.Load(dataPath);
    }
    /*XmlNodeList cards = doc.GetElementsByTagName("card");
    foreach (XmlNode cardInfo in cards)
    {
      Card card = new Card(cardInfo);
      Console.WriteLine(card.GetName());
      Console.WriteLine(card.GetLeftAction().InnerXml);
    }*/
    int[] amounts = {2, 2, 1, 5};
    Deck deck = new Deck(doc, amounts);
    deck.FisherYatesShuffle();
    /*Console.WriteLine(deck.DrawOne());
    Console.WriteLine(deck.DrawOne());
    Console.WriteLine(deck.DrawOne()); */
    Console.WriteLine("-----------------------");
    //Console.WriteLine(Alignment.Detroit.ToString());
    Enemy ig = new Enemy();
    Console.WriteLine(ig.ToString());
    Console.ReadLine();
    return 0;
  }
}

class Card {

  private String name = "foo";
  private String longname = "foobar";
  private XmlNode leftAction;
  private XmlNode rightAction;
  private XmlNode upAction;
  private XmlNode downAction;

  public Card(XmlNode cardInfo) {
    foreach (XmlNode node in cardInfo.ChildNodes) {
      if (node.Name == "name") { // just a coincidence that the Name is "name"
        this.name = node.InnerXml;
      }
      else if (node.Name == "longname") {
        this.longname = node.Value;
      }
      else if (node.Name == "left") {
        this.leftAction = node;
      }
      else if (node.Name == "right") {
        this.rightAction = node; 
      } 
      else if (node.Name == "up") {
        this.upAction = node;
      }
      // don't look down
      /*else if (node.Name == "down") {
        this.downAction = node;
        }*/
    }
  }

  public String GetName()
  {
    return this.name;
  }

  public String GetLongname()
  {
    return this.longname;
  }

  public XmlNode GetLeftAction()
  {
    return this.leftAction;
  }

  public XmlNode GetRightAction()
  {
    return this.rightAction;
  }

  public XmlNode GetUpAction()
  {
    return this.upAction;
  }

  public XmlNode GetDownAction()
  {
    throw new NotImplementedException();
  }

  public override String ToString()
  {
    return "[" + this.name + "]";
  }
}

class Deck {

  protected List<Card> tableDeck;
  protected List<Card> hand;
  protected List<Card> discardPile;
  protected List<Card> graveyard;

  public Deck(XmlDocument cardsDoc, int[] amounts) {
    tableDeck = new List<Card>();
    hand = new List<Card>();
    XmlNodeList types = cardsDoc.GetElementsByTagName("card");
    for (int i = 0; i < types.Count; i++) {
      if (types.Count > amounts.Length)  { throw new NotImplementedException();}
      for(int j = 0; j < amounts[i]; j++) {

        tableDeck.Add(new Card(types[i]));
      }
    }
  }

  public void FisherYatesShuffle() {
    int n = tableDeck.Count;
    while(n > 1) {
      n--;
      int k = MainLoop.rng.Next(n + 1);
      Card swapValue = tableDeck[k];
      tableDeck[k] = tableDeck[n];
      tableDeck[n] = swapValue;
    }
  }

  public bool DrawOne() {
    if (tableDeck.Count < 1)  
      return false;
    Card ret = tableDeck[0];
    tableDeck.RemoveAt(0);
    hand.Add(ret);
    return true;
  }

  public void Draw(int amount) {
  while(amount > 0)
  {
    if(DrawOne())
    {}
    else
    {
      tableDeck = discardPile;
      discardPile = new List<Card>();
      FisherYatesShuffle();
      DrawOne();
    }
    amount--; // naturally goes to 0 if no cards actually drawn
  }
}
public enum Alignment {
  Fae,
  Independent,
  Goblin,
  PowerHungry,
  Underground,
  Decept,
  Demon,
  Imp,
  NullExceptions,
  Ghoul
}

class Creature {
  protected int health;
  protected int maxHealth;
  protected Alignment align;
  protected int manaLevel;
  protected String name;

  public Creature(int health, int maxHealth, String name, Alignment align=Alignment.Independent, int manaLevel=0) {
    this.health = health;
    this.maxHealth = maxHealth;
    this.align = align;
    this.manaLevel = manaLevel;
    this.name = name;
  }
  public int GetHealth()
  {
    return this.health;
  }

  public int GetMaxHealth()
  {
    return this.maxHealth;
  }

  public Alignment GetAlignment()
  {
    return this.align;
  }

  public int GetManaLevel() {
    return this.manaLevel;
  }

  public void ModifyMana(int amount)
  {
    this.manaLevel += amount;
  }

  public float ManaSaturation()
  {
    return (manaLevel + 0.0f)/(maxHealth + 0.0f);
  }
}

class Enemy : Creature {
  public Enemy(int health=15):base(health,health,"ig")
  {

  }

  public Enemy(int health, int maxHealth, String name, Alignment align = Alignment.Goblin, int manaLevel=0):base(health, maxHealth, name, align, manaLevel)
  {
    throw new NotImplementedException();
    //add cards to enemy deck
  }

  public override String ToString()
  {
    return "hello, Scum!, my name is " + base.name + " and my health is "
      + base.health + " out of "+ base.maxHealth;
  }
}

class StateManager {
  private Creature player = new Creature(100, 100, "<placeholder name>", Alignment.Underground, 0);



}
