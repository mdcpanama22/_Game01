//Description: container and manager class for pieces on the board.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardObject : MonoBehaviour {
	public GameObject veryTemporarySpellListComponentWhichShouldBeRemovedASAP;
	public int x, y;
	public int moves, attack, range, attacks = 1;
	public int[] resources;
	public List<Spell> spellBook;
	//creates a BoardObject shell which only tracks its x and y coordinates
	public void InitializeAsEmpty(int nx, int ny){
		x = nx;
		y = ny;
		name = "empty";
		//gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}
	
	public void InitializeAsPlayer(string n){
		name = n;
		DontDestroyOnLoad(gameObject);
	}
	
	public void OnMouseDown(){
		BoardManager bm = GameObject.FindWithTag("Board").GetComponent<BoardManager>();
		bm.Receive(x,y);
	}
	public void DisplaySpells(){
		for(int i=0; i<spellBook.Count; i++){
			GameObject st = Instantiate(veryTemporarySpellListComponentWhichShouldBeRemovedASAP) as GameObject;
			st.transform.SetParent(GameObject.Find("ButtonHolder").transform);
			st.transform.position += i * new Vector3(0,30,0);
			st.GetComponent<TempSpellSelectButton>().AddSpell(spellBook[i]);
			st.GetComponentInChildren<Text>().text = spellBook[i].name;
		}
	}
	
	public void CopyTo(BoardObject bo){
		
	}
	
	public void BuildDarkMonolith(){
		gameObject.GetComponent<SpriteRenderer>().color = Color.black;
	}
	
	public void BuildWisp(){
		gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
	}
	
	public void BuildWraith(){
		gameObject.GetComponent<SpriteRenderer>().color = Color.red;
	}
	
	public void BuildSkeleton(){
		gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
	}
}