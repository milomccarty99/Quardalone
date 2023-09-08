using System;
using System.IO;
using System.Xml;

class Dealer
{
  private static int width = 100;
  private static int height = 30;
  private static char[] outputBuffer = new char[width*height];
  private static Card selectMove = null;

  public static void SetLeft()
  {

  }

  public static void SetRight()
  {

  }

  public static void PrintCard(String directionLeft, String directionRight)
  {
    Console.Write("------------------------");
    Console.WriteLine("     ------------------------");
    int counter = 0;
    int textWidth = 20;
    for(int i = 0; i < 20; i++)
    {
      Console.Write("|");
      while(counter%21 < textWidth)
      {
        Console.Write(directionLeft[counter]);
        counter++;
      }
      Console.Write(directionLeft[counter]);
      counter++;
      
    }
  
  }


  public static void Main()
  {
    Console.Write("H e l l o");
    Console.WriteLine();
    PrintCard("The action left is what the player will choose though this will inevitably lead to their downfall", "This action will be overly aggressive and will eventually lead to player downfall");
  }

}

class Card 
{
  private String leftText;
  private String rightText;

  public Card(XmlNode cardInfo){
    this.leftText = cardInfo.InnerXml;
    this.rightText = cardInfo.InnerXml;
  }

  public String GetRightText()
  {
    return this.rightText;
  }

  public String GetLeftText()
  {
    return this.leftText;
  }
}
