using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

public enum Direction {
  Left,
  Right,
  Up
}

class StateManager {
  protected String xmlCardFilePath;
  protected String xmlEnemyFilePath;
  protected int numLevels;
  protected int currentLevel;
  protected Deck deck;
  protected CreatureOrganizer co;

  //statei-machine trackers
  protected Stack<Direction> playStack; //play cards from here until you cannot
  protected int upCounter; //counts every up (null) action;
  public StateManager(String xmlCardFilePath, String xmlEnemyFilePath, String playerName,int levels = 5)
  {
    this.xmlCardFilePath = xmlCardFilePath;
    this.xmlEnemyFilePath = xmlEnemyFilePath;
    this.numLevels = levels;
    this.currentLevel = 0;
    this.deck = new Deck(xmlCardFilePath);


  }

  public bool CheckLevelProgression()
  {
    throw new NotImplementedException();
  }

  public int GetCurrentLevel()
  {
    return this.currentLevel;
  }

  public List<Enemy> GetCurrentActiveEnemies() {
    throw new NotImplementedException();
  }
  
  public bool PerformActionToEnemy(XmlNode action, Enemy enemy)
  {
    throw new NotImplementedException();
  }

  public bool PerformAction(XmlNode action)
  {
    throw new NotImplementedException(); // maybe build out a class or 
    //a few methods at minimum.
  }

  private bool ActionAttack()
  {
    throw new NotImplementedException();
  }

  private bool ActionBlock()
  {
    throw new NotImplementedException();
  }

  private bool ActionNoise(String data) 
  {
    throw new NotImplementedException();
  }

  private bool ActionPushToPlayStack(String data) //forceplay
  {
    throw new NotImplementedException();
  }
  
  private bool ActionAnticreature(XmlNode Data) 
  { 
    // account for actions triggering on specific enemy
    throw new NotImplementedException();
  }
  
  private bool ActionForcedAction(XmlNode action)
  {
    // if action was forced, then play ability
    throw new NotImplementedException();
  }


}

class CreatureOrganizer {
  public CreatureOrganizer(XmlNodeList creatures) {
    //throw new NotImplementedException();
  }

  public bool IsEnemy(Creature creep) 
  {
    return creep.GetType().Equals(Enemy);
  }

  public bool SelectRandomEnemy(int number,String[] names = null) {
    throw new NotImplementedException();
  }

  public bool SelectRandomEnemy(String name = null) { //just one
    throw new NotImplementedException();
  }

}
