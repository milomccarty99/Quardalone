using System;
using System.IO;
using System.Xml;

class MainLoop {
  public static int Main() {

    XmlDocument doc = new XmlDocument();
    doc.Load("cards.xml");
    XmlNodeList cards = doc.GetElementsByTagName("card");
    foreach (XmlNode cardInfo in cards)
    {
      Card card = new Card(cardInfo);
      Console.WriteLine(card.GetName());
      Console.WriteLine(card.GetLeftAction().InnerXml);
    }
    Console.WriteLine("-----------------------");
    //Console.WriteLine(Alignment.Detroit.ToString());
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
}

public enum Alignment {
  Fae,
  Independent,
  Goblin,
  PowerHungry,
  Underground,
  Detroit,
  Demon,
  Imp,
  Nonce,
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
  
  public Enemy(int health, int maxHealth, String name, Alignment align = Alignment.Goblin, int manaLevel=0)
  {
    throw new NotImplementedException();
    //add cards
  }

  public override String ToString()
  {
    return "hello, Scum!, my name is " + base.name + "and my health is "
      + base.health + "out of"+ base.maxHealth;
  }
}
