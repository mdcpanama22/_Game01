//Author: Ben Eid
//Description: Container class for the CharacterSelectUI. Holds a description of a summoner, and an image.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelectTile : MonoBehaviour, IPointerClickHandler{
	public string description;
	
	//Called when this object is clicked on. Sends the data on this tile to the character select UI; Changes the color of the selected tile.
	public void OnPointerClick(PointerEventData pointerEventData){
		gameObject.GetComponentInParent<CharacterSelect>().ReceiveCharacter(name, description);
		gameObject.GetComponent<Image>().color = Color.green;
	}
}