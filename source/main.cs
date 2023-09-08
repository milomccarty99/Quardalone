using System;
using System.IO;


class Game 
{
  public static void Main() 
  {
    Console.WriteLine("Hello Gamer");
  }
//gets health 
//sets health 
//modifies health
//
//
//takes Xml Document and returns a Deck
//takes a deck and returns a deck with 1 less card and the Card drawn
//
}

class Card
{
  private int leftBlock;
  private int rightAttack;
  public int GetBlock()
  {
    return leftBlock;
  }
  public int GetAttack()
  {
    return rightAttack;
  }
  private String text = "placeholder text until I get a system implemented";
  public String GetText()
  {
    return this.text;
  }

  public void SomeEffect(ref Enemy em)
  {
    if (em.TypeDef() == Manticore)
    {
      em.TakeSP();
      Console.WriteLine("Special Damage");
    }
  }

  public Card(int block, int attack)
  {
    this.leftBlock = block;
    this.rightAttack = attack;
    //this.text = "placeholder text, but it is applied in the original definition"
  }
}
