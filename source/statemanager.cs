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
  protected Player player;


  //state-machine trackers
  protected Stack<Direction> playStack; //play cards from here until you cannot
  protected int upCounter; //counts every up (null) action;
  public StateManager(String xmlCardFilePath, String xmlOtherCreatureFilePath,int[] amounts, Player player,int levels = 5)
  {
    this.xmlCardFilePath = xmlCardFilePath;
    this.xmlEnemyFilePath = xmlEnemyFilePath;
    this.numLevels = levels;
    this.currentLevel = 0;
    this.player = player;
    //we assume some parsing before handing off cardDoc to decka
    Console.WriteLine("Loading cards.xml cardpack");
    XmlDocument cardDoc = new XmlDocument();
    cardDoc.Load(xmlCardFilePath);
    this.deck = new Deck(cardDoc, amounts);
    //Console.WriteLine(deck);
    Console.WriteLine("Loading creatures.xml pack");
    XmlDocument otherCreatureDoc = new XmlDocument();
    otherCreatureDoc.Load(xmlOtherCreatureFilePath);
    co = new CreatureOrganizer(otherCreatureDoc);

  }

  public void StartPlayerTurn()
  {
    throw new NotImplementedException();
  }

  public void PlaySelection(int selection)
  {
    throw new NotImplementedException();
  }

  public List<Card> GetHand() {
    return deck.GetHand();
  }

  public void Draw(int amount)
  {
    deck.Draw(amount);
  }

  public void DrawOne()
  {
    this.Draw(1);
  }

  public List<Creature> GetActiveCreatures()
  {
    return co.GetActiveCreatures();
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
  List<Creature> possibleEntities;
  public CreatureOrganizer(XmlDocument creatures) {
    possibleEntities = new List<Creature>();
    XmlNodeList typesOfCreatures = creatures.GetElementsByTagName("enemy"); // only enemy for now...
    for(int i = 0; i < typesOfCreatures.Count; i++) 
    {
      possibleEntities.Add(new Creature(typesOfCreatures[i]));
    }


  }

  

  public bool IsEnemy(Creature creep) 
  {
    return Enemy.Equals(creep.GetType(),typeof(Enemy));
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

  public List<Creature> GetActiveCreatures()
  {
    throw new NotImplementedException();
  }
}
