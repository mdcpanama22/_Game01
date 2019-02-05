//Description: Manager class for the SpellSelectUI. Manages how many tiles there are, their color.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSelect : MonoBehaviour{
	private int maxSpells = 5;
	public List<Spell> spells = new List<Spell>();
	
	public GameObject spellTilePrefab;
	
	//generated a spellSelectTile for all the spells passed to this object.
	public void Initialize(List<Spell> sb){
		SpellSelectTile nextSpellSelectTile;
		foreach(Spell s in sb){
			GameObject st = Instantiate(spellTilePrefab) as GameObject;
			st.transform.SetParent(transform);
			nextSpellSelectTile = st.GetComponent<SpellSelectTile>();
			nextSpellSelectTile.spell = s;
			st.transform.GetChild(0).gameObject.GetComponent<Text>().text = nextSpellSelectTile.name;
			st.gameObject.GetComponentsInChildren<Image>()[1].enabled = false;
		}
	}
	
	//Called when one of the chile SPellSelectTiles is clicked on. Handles adding/removing spells from its list and helps change colors of SpellSelectTiles.
	public bool ReceiveSpell(bool b, Spell s){
		SpellSelectTile[] ssta = gameObject.GetComponentsInChildren<SpellSelectTile>();
		for(int i=0; i< ssta.Length; i++){
			ssta[i].gameObject.GetComponentsInChildren<Image>()[1].enabled = false;
		}
		if(b){
			if(spells.Count < 1){
				Debug.Log("something has gone wrong");
				return true;
			}
			spells.Remove(s);
			if(spells.Count == maxSpells - 1){
				for(int i=0; i< ssta.Length; i++){
					ssta[i].gameObject.GetComponent<Image>().color = (ssta[i].pressed)? Color.green : Color.grey;
				}
			}
			return false;
		} else {
			if(spells.Count > maxSpells - 1){
				Debug.Log("You have too many spells");
				return false;
			}
			spells.Add(s);
			if(spells.Count > maxSpells - 1){
				for(int i=0; i< ssta.Length; i++){
					ssta[i].gameObject.GetComponent<Image>().color = (ssta[i].pressed)? Color.green : Color.red;
				}
			}
			return true;
		}
	}
	
	public void Print(){
		foreach (Spell s in spells){
			Debug.Log("SpellBook: " + s.name);
		}
	}
}