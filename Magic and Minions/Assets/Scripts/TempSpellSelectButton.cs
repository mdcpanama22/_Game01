using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSpellSelectButton : MonoBehaviour {
	public Spell heldSpell;
	// Use this for initialization
	void Start () {
		
	}
	
	public void AddSpell(Spell s){
		heldSpell = s;
	}
	
	public void CastSpell(){
		heldSpell.Cast();
	}
}
