using System;
//using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

public class Enemy
{
  private int health = 20;
  private int attack = 5;

  public Enemy()
  {
    this.health = 21;
    this.attack = 6;
    AttributeAttack(null);
  }
  
  public String AttackPhase()
  {
    return "Swipe";
  }

  public int BlockPhase(int attack, int specialAttack)
  {
    this.health -= attack;
    this.health -= specialAttack * 4;

    return this.health;
  }

  public int AttributeAttack(XmlNode right)
  {
    throw new NotImplementedException();
  }
}
