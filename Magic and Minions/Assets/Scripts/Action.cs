//Description: container class for a location and a verb to apply.

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Action {
	public int magnitude;
	public BoardObject[] locations;
	
	public Action(){}
	
	public Action(int m){
		magnitude = m;
	}
	
	public BoardObject[] RectangleTarget(int x1, int y1, int x2, int y2){
		BoardObject[,] tiles = GameObject.FindWithTag("Board").GetComponent<BoardManager>().tiles;
		int xMax, xMin, yMax, yMin = 0;
		if(x1 > x2){
			xMax = x1;
			xMin = x2;		
		} else {
			xMax = x2;
			xMin = x1;
		}
		if(y1 > y2){
			yMax = y1;
			yMin = y2;		
		} else {
			yMax = y2;
			yMin = y1;
		}
		BoardObject[] targets = new BoardObject[(xMax - xMin + 1) * (yMax - yMin + 1)];
		for(int i=xMin; i<=xMax; i++){
			for(int j=yMin; j<=yMax; j++){ 
				targets[i * (yMax - yMin + 1) + j] = tiles[i,j];
			}
		}
		return targets;
	}
	
	public void PrintLocations(){
		for(int i=0; i<locations.Length; i++){
			Debug.Log("<" + locations[i].x + "," + locations[i].y + ">");	
		}
	}
	
	public virtual void Enact(){
		PrintLocations();
	}
}

public class Damage : Action{
	
	public override void Enact(){
		
	}
	
	public string Print(){
		return "Damage|" + magnitude;
	}
}

public class Heal : Action{
	
	public override void Enact(){
		
	}
	
	public string Print(){
		return "Heal|" + magnitude;
	}
}

public class Summon : Action{
	public BoardObject toSummon;
	
	public Summon(BoardObject ts){
		toSummon = ts;
	}
	
	public override void Enact(){
		for(int i=0; i<locations.Length; i++){
			locations[i].copy(toSummon);
		}
	}
	
	public string Print(){
		return "Summon|" + magnitude;
	}
}

public class Push : Action{
	
	public BoardObject target;
	public int direction;
	
	public Push(BoardObject l, BoardObject t, int d){
		target = t;
		direction = d;
	}
	
	public override void Enact(){
		//target = location;
		//location = null;
		switch(direction){
			case 0:
				target.gameObject.transform.position += new Vector3(0f,0f,0.055f);
				break;
			case 1:
				target.gameObject.transform.position += new Vector3(0f,0f,-0.055f);
				break;
			case 2:
				target.gameObject.transform.position += new Vector3(0.055f, 0f, 0f);
				break;
			case 3:
				target.gameObject.transform.position += new Vector3(-0.055f, 0f, 0f);
				break;
			default:
				break;
		}
	}
	
	public string Print(){
		return "Push|" + magnitude;
	}
}