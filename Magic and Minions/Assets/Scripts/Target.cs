//Description: holds a list of boardactors to target.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target{
	public int squareMax = 8;
	public BoardObject[] targets;
	public BoardObject[,] tiles = GameObject.FindGameObjectsWithTag("Board")[0].GetComponent<BoardManager>().tiles;
	
	public void Print(){
		Debug.Log("targets: ");
		for(int i=0; i<targets.Length; i++){
			Debug.Log("<" + targets[i].x + "," + targets[i].y + ">");	
		}
	}
}