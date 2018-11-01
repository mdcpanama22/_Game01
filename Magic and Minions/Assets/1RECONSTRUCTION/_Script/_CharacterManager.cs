using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterManager : MonoBehaviour {
    public GameObject SysManager;
	// Use this for initialization
	void Start () {
        SysManager = GameObject.FindGameObjectWithTag("EventManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    private void OnMouseOver()
    {
        SysManager.GetComponent<SpellList>().ShowSpells(GM.instance.turn % GM.instance.GetAmountofPlayers(), this.GetComponent<Type>().CharacterType);
        SysManager.GetComponent<SpellList>().RelocateSpellUI(this.transform.gameObject);
        SysManager.GetComponent<SpellList>().PlayerSpellUI.SetActive(true);
    }
    private void OnMouseExit()
    {
        SysManager.GetComponent<SpellList>().PlayerSpellUI.SetActive(false);
    }*/
}
