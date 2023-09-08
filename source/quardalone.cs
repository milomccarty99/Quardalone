using System;
using System.Threading;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

class Quardalone
{
  static void Main()
  {
    //bootup sequence and reading files
    Console.Clear();
    Console.WriteLine(File.ReadAllText("title.txt"));
    XmlDocument docu = new XmlDocument();
    docu.Load("cards.xml");
    // sleep for style
    Thread.Sleep(600);
    Console.Clear();
    //Console.WriteLine(docu.GetElementsByTagName("card")[0].InnerText);
    XmlNodeList cards = docu.GetElementsByTagName("card");

    for(int i = 0; i < cards.Count; i++)
    {
      //Console.WriteLine(cards[i].InnerText);
    }
    Deck dk = new Deck(cards.Cast<XmlNode>().ToList());
    dk.ShuffleDeck();
    PrintCard(dk.DrawTop());
    Console.ReadLine();
    Console.WriteLine("Main thread exits.");
    // To-Do:
    //
    // card picker for starting deck
    // turn system
    //  - enemy attack
    //  - play a single card
    // attack sys
    // block sys
    // antimanticore
  }

  public static void PrintCard(XmlNode card)
  {

    Console.WriteLine(card.FirstChild.InnerText);
  }


}

public class Picker
{
  public Picker(Deck deck){
    for(int i = 0; i < 5; i++)
    {
      deck.DrawOneFreeform();
    }
  }


}
