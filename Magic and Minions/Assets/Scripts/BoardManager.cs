//Description: Manages the board for the game. Including all the pieces on the board.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour {
	public Queue<Action> actionsToBeDone;
	
	public GameObject boardObject;
	
	private int boardSize;
	public BoardObject selectedBoardObject, targetedBoardObject;
	public BoardObject[,] tiles;
	
	private Vector3 verticalShift = new Vector3(0f,0.055f,0f);
	private Vector3 horizontalShift = new Vector3(0.055f, 0f, 0f);
	
	// Use this for initialization
	void Start () {
		GenerateBoard(8);
		actionsToBeDone = new Queue<Action>();
	}
	
	public void Update(){
		if (Input.GetMouseButtonDown(1)){
			RemoveSpellList();
			selectedBoardObject = null;
			targetedBoardObject = null;
		}
	}
	
	public void RemoveSpellList(){
		GameObject master = GameObject.Find("ButtonHolder");
		foreach( Transform t in master.transform){
			Destroy(t.gameObject);
		}
	}
	
	public void Receive(int x, int y){
		if(selectedBoardObject == null){
			selectedBoardObject = tiles[x,y];
			selectedBoardObject.DisplaySpells();
			Debug.Log("new tile selected");
		} else {
			targetedBoardObject = tiles[x,y];
			Debug.Log("New tile targeted");
		}
		
	}
	
	//used to generate a representation of the board on a grid of BoardActors 
	public void GenerateBoard(int bs){
		boardSize = bs;
		tiles = new BoardObject[boardSize,boardSize];
		for(int x=0; x<boardSize; x++){
			for(int y=0; y<boardSize; y++){
				GameObject st = Instantiate(boardObject) as GameObject;
				st.transform.SetParent(transform);
				st.transform.position = x*verticalShift + y*horizontalShift;
				tiles[x,y] = st.GetComponent<BoardObject>();
				tiles[x,y].InitializeAsEmpty(x,y);
			}
		}
		AddSpells(tiles[0,0]);
	}
	
	public BoardObject ObjectAt(int x, int y){
		return tiles[x,y];
	}
	
	public void AddSpells(BoardObject bo){
		bo.spellBook = new List<Spell>();
		bo.spellBook.Add(new Wisp(bo));
		bo.spellBook.Add(new Skeleton(bo));
		bo.spellBook.Add(new Wraith(bo));
		bo.spellBook.Add(new Possession(bo));
		bo.spellBook.Add(new SoulSwarm(bo));
		bo.spellBook.Add(new SoulInhale(bo));
		bo.spellBook.Add(new DarkMonolith(bo));
		bo.spellBook.Add(new EnergySling(bo));
		bo.spellBook.Add(new EssenceProjection(bo));
		bo.spellBook.Add(new SoulRot(bo));
		bo.spellBook.Add(new Plague(bo));
		bo.spellBook.Add(new RisingDarkness(bo));
		//bo.spellBook = spellBook;
	}
}