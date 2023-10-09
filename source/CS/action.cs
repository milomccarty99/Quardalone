using System;
using System.Xml;

class Action {
  private Direction dir;
  public Action(XmlNode data)
  {
    switch(data.OuterXml){
      case "Left":
        dir = Direction.Left;
        break;
      case "Right": 
        dir = Direction.Right;
        break;
      case "Up":
        dir = Direction.Up;
        break;
      default:
        dir = Direction.Up;
        break;
    }

  }

  public void PerformAction(StateManager sm) {
    
  }
}
