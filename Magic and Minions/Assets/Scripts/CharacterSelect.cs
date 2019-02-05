//Author: Ben Eid
//Description: Creates and magages a grid of selectable characters. Including the colors of the UI elements and their content.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {
	public GameObject characterSelectTile;
	public string potentialCharacterName;
	
	//Creates an appropriate set of character tiles from an array of strings
	public void Initialize(string[] characters){
		for(int i=0; i<characters.Length; i++){
			GameObject cst = Instantiate(characterSelectTile) as GameObject;
			cst.transform.SetParent(transform);
			cst.GetComponent<CharacterSelectTile>().name = characters[i].Split('|')[0];
			cst.GetComponent<CharacterSelectTile>().description = characters[i].Split('|')[1];
		}
	}
	
	//Called when a CharacterSelectTile is chosen. Updates the currently selected character name, and the description.
	public void ReceiveCharacter(string s, string d){
		potentialCharacterName = s;
		gameObject.GetComponentInParent<SelectionUI>().ReceivePreviewText(d);
		CharacterSelectTile[] csta = gameObject.GetComponentsInChildren<CharacterSelectTile>();
		for(int i=0; i< csta.Length; i++){
			csta[i].gameObject.GetComponent<Image>().color = Color.grey;
		}
	}
}