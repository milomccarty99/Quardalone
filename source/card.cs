using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Collections.Generic;

class MainLoop {
  public static Random rng = new Random();

  public static int Main() {
    // get card XmlDocument
    XmlDocument doc = new XmlDocument();
    doc.Load("data/cards.xml");
    //optional card path
    //String dataPath = Console.ReadLine();
    if (dataPath.Length > 0) {
      doc.Load(dataPath);
    }
    // define actual card paths
    String xmlCardFilePath = "data/cards.xml";
    String xmlCreatureFilePath = "data/creatures.xml";
    // define amounts
    int[] amounts = {2, 2, 1, 5};
    // input define player name
    Console.Write("Please enter the player name: ");
    String playerName = Console.ReadLine();
    //create player object
    Player player = new Player(playerName, Alignment.Independent);
    // open a picture :)
    Process fotoViewer = new Process();
    fotoViewer.StartInfo.FileName = @"open";
    fotoViewer.StartInfo.Arguments = "quardalone_logo.png";
    fotoViewer.Start();

    /*XmlNodeList cards = doc.GetElementsByTagName("card");
      foreach (XmlNode cardInfo in cards)
      {
      Card card = new Card(cardInfo);
      Console.WriteLine(card.GetName());
      Console.WriteLine(card.GetLeftAction().InnerXml);
      }*/
    /*Console.WriteLine(deck.DrawOne());
      Console.WriteLine(deck.DrawOne());
      Console.WriteLine(deck.DrawOne()); */
    Console.WriteLine("-----------------------");
    //Console.WriteLine(Alignment.Detroit.To:w
    //String());
    //Enemy ig = new Enemy();
    //Console.WriteLine(ig.ToString());
    //
    //
    //winCon is set to false
    bool winCon = false;
    
    // instantiate StateManager sm
    StateManager sm = new StateManager(xmlCardFilePath, xmlCreatureFilePath, amounts, player);
    // draw starting hand
    sm.Draw(6);
    while(!winCon)
    {
      List<Creature> enemies = sm.GetActiveCreatures();
      foreach (Enemy nme in enemies) {
        Console.WriteLine(nme.ToString());
      }
      //list cards
      //draw one
      sm.DrawOne();
      List<Card> hand = sm.GetHand();
      for (int i = 0; i < hand.Count; i++)
      {
        Console.WriteLine(hand[i].ToString() + ": " + i + "     ");
      }
      String selection = Console.ReadLine();
      //check for wincon TO DO
      winCon = sm.CheckWin();
    }
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

  public List<Card> GetHand()
  {
    return this.hand;
  }

  public override String ToString() {
    String ret = "Your hand consists of: ";
    for (int i = 0; i < hand.Count; i++) {
      ret += hand[i].ToString();
    }
    ret += ". And you have " + tableDeck.Count + " card(s) in your draw pile.";
    return ret;
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
  protected Deck deck;

  public Creature(int health, int maxHealth, String name, Alignment align=Alignment.Independent, int manaLevel=0) {
    this.health = health;
    this.maxHealth = maxHealth;
    this.align = align;
    this.manaLevel = manaLevel;
    this.name = name;
    
  }

  public Creature(XmlNode xmlNodeInfo)
  {
    for (int i = 0; i < xmlNodeInfo.ChildNodes.Count; i++)
    {
      XmlNode searchNode = xmlNodeInfo.ChildNodes[i];
      if(searchNode.Name == "health")
      {
        this.health = int.Parse(searchNode.InnerXml);
        this.maxHealth = health;
      }
      else if (searchNode.Name == "maxhealth")
      {
        this.maxHealth = int.Parse(searchNode.InnerXml);
      }
      else if (searchNode.Name == "alignment")
      {
        this.align = Enum.Parse<Alignment>(searchNode.InnerXml);
      }
      else if (searchNode.Name == "startingmana")
      {
      }

    }
  }
  public int GetHealth()
  {
    return this.health;
  }

  public int GetMaxHealth()
  {
    return this.maxHealth;
  }

  public String GetName()
  {
    return this.name;
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

class Player : Creature {
  public Player(String playerName, Alignment align, int startingHealth = 100):base(startingHealth, startingHealth, playerName, align, 0)
  {

  }

}
