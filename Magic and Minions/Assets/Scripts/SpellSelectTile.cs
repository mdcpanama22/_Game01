//Description: Container class for the CharacterSelectUI. Holds a spell, and an image.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellSelectTile : MonoBehaviour, IPointerClickHandler{
	public Spell spell;
	public bool pressed;
	
	//Called when this object is clicked on. Changes the color of the tile to reflect if it is in the selected tile group.
	public void OnPointerClick(PointerEventData pointerEventData){
		gameObject.GetComponentInParent<SelectionUI>().ReceivePreviewText(spell.description);
		pressed = gameObject.GetComponentInParent<SpellSelect>().ReceiveSpell(pressed, spell);
		gameObject.GetComponent<Image>().color = (pressed)? Color.green : ((gameObject.GetComponent<Image>().color == Color.red)? Color.red : Color.gray);
		gameObject.GetComponentsInChildren<Image>()[1].enabled = true;
	}
}