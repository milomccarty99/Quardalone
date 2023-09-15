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

  //state-machine trackers
  protected Stack<Direction> playStack; //play cards from here until you cannot
  protected int upCounter; //counts every up (null) action;
  public StateManager(String xmlCardFilePath, String xmlEnemyFilePath,int[] amounts, String playerName,int levels = 5)
  {
    this.xmlCardFilePath = xmlCardFilePath;
    this.xmlEnemyFilePath = xmlEnemyFilePath;
    this.numLevels = levels;
    this.currentLevel = 0;
    
    this.deck = new Deck(xmlCardFilePath,amounts);
    Console.WriteLine(deck);

  }

  public void StartPlayerTurn()
  {
    throw new NotImplementedException();
  }

  public void PlaySelection(int selection)
  {
    throw new NotImplementedException();
  }

  public void GetHand() {
    throw new NotImplementedException();
  }

  private bool CheckHandViability()
  {
    throw new NotImplementedException();
  }

  public void EndTurn() {
    throw new NotImplementedException();
  }

  private void Mulligan() {
    throw new NotImplementedException();
  }

  private void RemainingPlays() {
    throw new NotImplementedException();
  }
  
  public int GetRemainingCards() {
    throw new NotImplementedException();
  }

  public List<Card> ViewTopDraw(int depth) {
    throw new NotImplementedException();
  }

  private void ScryTopCards(int depth)
  {
    throw new NotImplementedException();
  }

  private void MagnetRandomCard()
  {
    // obtain a copy of a card in your hand and one in your opponents hand
    // choose to keep one.
    throw new NotImplementedException();
  }

  public bool CheckLevelProgression()
  {
    throw new NotImplementedException();
  }

  public int GetCurrentLevel()
  {
    return this.currentLevel;
  }

  public List<Enemy> GetCurrentActiveCreatures() {
    throw new NotImplementedException();
  }
  
  public bool PerformActionToCreature(XmlNode action, Creature enemy)
  {
    throw new NotImplementedException();
  }

  public bool PerformActionToManyCreatures(XmlNode action, List<Creature> manyCreatures)
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

  public Creature SelectIndexedCreature(int index)
  {
    throw new NotImplementedException();
  }

}
