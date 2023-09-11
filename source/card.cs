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
}
