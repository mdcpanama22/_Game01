//original file by matt
//used by EventSystem
//used for Navigating the menus for selection of characters and spells



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _CharacterSelection : MonoBehaviour {
	public int num, np1, np2;
	
	public Text P1, P2, SpellD;
	
	public GameObject NumberofPlayers, CharSelection, SpellSelection, SpellSelection2, Undo_b, Ready_G, Ready_b, Ready_b2, Description_b, Beserker, Necro, ClassTemp, ALLSPELLS, Character_Select_Menu;
	//public GameObject GM;
	
	public string SpellName;
	
	public Sprite SpellImage;
	
	public Camera CameraMovement;
	
	private int Max_, state_, _spellDescription;
	private int Min_ = -1234; // Will be used as a way to stop running zombie code
	
	private List<GameObject> SpellSelectionList;
	
	private Button ChosenSpell;

	//Camera Movement
	IEnumerator StartMatch(){
		yield return new WaitForSeconds(CameraMovement.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + CameraMovement.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
	}
	
	// Use this for initialization
	void Start(){
		num = 0; // player count
		np1 = 0;
		np2 = 0;
		state_ = 0;
		_spellDescription = 0; //0 == false 1 == true this is for the spell description
		NumberofPlayers.SetActive(true);
		CharSelection.SetActive(false);
		SpellSelection.SetActive(false);

		SpellSelectionList = new List<GameObject>(){
			SpellSelection,
			SpellSelection2
		};

		P1.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update(){
		if(num != Min_){
			if(num == Max_ && num != 0){
				CharSelection.SetActive(false);
				SpellSelectionSelector();
				state_++;
			}
			if(state_ == 0){
				P1.text = "How many players are playing?";
			} else if(state_ == 1){
				P1.text = PlayerChoiceDialogue(num);
			} else {
				if(np1 < Max_){
					P1.text = PlayerChoiceSpellDialogue(np1);
				}
			}
		}
	}
	
	//Dialogue
	public string PlayerChoiceDialogue(int n){
		return "Player " + (n + 1) + ", Choose Your Magician:";
	}
	
	public string PlayerChoiceSpellDialogue(int n){
		int number = GM.instance.Players[n].SpellTotal + 1;
		string a = "Player " + (n + 1) + ", Choose your " + number;
		if(number == 1){
			a += "st Spell";
		} else if(number == 2){
			a += "nd Spell";
		} else if(number == 3){
			a += "rd Spell";
		} else {
			a += "th Spell";
		}
		return a;
	}
	
	//Amount of Players
	public void PlayerAmount(int players){
		GM.instance.SetAmountofPlayers(players);
		NumberofPlayers.SetActive(false);
		CharSelection.SetActive(true);
		Max_ = players;
		state_++;
	}
	
	//Classes
	/*
	* PickClass:
			Happens when a player is selecting a Magician. Everytime they click a Magician the ClassTemp will be assigned to that Magician (C is declared in the button editor)
			This will also take the chance to update the description for the magician chosen
	* 
	*/
	public void PickClass(GameObject C){
		ClassTemp = C;
		Ready_b.SetActive(true);
		Description(Description_b.transform.childCount);
	}
	
	//Spells
	//Sets Name of Spell
	public void PickSpell(string name){
		SpellName = name;
		SpellDesciption();
		Ready_b2.SetActive(true);
	}
	
	//Obtains the corresponding button
	public void PickSpell(Button B){
		ChosenSpell = B;
	}

	//Activates the right panel to display information
	public void SpellSelectionSelector(){
		if (np1 < Max_){
			foreach(GameObject i in SpellSelectionList){
				if (GM.instance.Players[np1].Character.gameObject.tag == i.tag){
					i.SetActive(true);
				} else {
					i.SetActive(false);
				}
			}
		} /* Exit Code */ else {
			foreach (GameObject i in SpellSelectionList){
				i.SetActive(false);
			}
			num = Min_;
			Ready_G.SetActive(true);
		}
		// ^^^ EXIT CODE
		if (np2 == 5){ //Increment to next on the list
			np2 = 0;
			np1++;
			GM.instance.ResetButtons();
		}

	}
	
	//Basic Spell Commands for Description
	public void SpellDesciption(){
		_spellDescription = 1;
		foreach (SpellList.Tag T in ALLSPELLS.GetComponent<SpellList>().ALLSPELLS){
			if(GM.instance.Players[np1].Character.tag == T.tag){
				foreach(SpellList.Spell S in T.spell){
					if(S.Name == SpellName){
						SpellImage = S.Spell_Image;
						SpellDescription(S);
						Description(Description_b.transform.childCount);
						_spellDescription = 0;
					}
				}
			}
		}
	}
	
	public void SpellDescription(SpellList.Spell S){
		string temp = "";
		foreach(char x in S.Name){
			if(x.Equals('_')){
				temp += ' ';
			} else {
				temp += x;
			}
		}
		string a = "Name: " + temp + "\nDescription\n" + S.Description + "\n\nCost: ";
		for(int i = 0; i < S.MultipleCosts.Count; i++){
			a += S.Costs[i] + " " + S.MultipleCosts[i] ;
			if(i != S.MultipleCosts.Count - 1){
				a += " or ";
			} else {
				a += "\n";
			}
		}
		if(S.Range > 0){
			a += "Range: " + S.Range;
		} else if(S.Range == 0){
			a += "Passive";
		} else if(S.Range == -1){
			a += "Range: Self";
		}
		SpellD.text = a;
	}

	//Basic Commands: such that the UI is streamlined for character select
	public void Ready(){
		//ClassTemp is assigned in PickClass which is when the description is updated and the player clicked the button
		GM.instance.SetPlayer(num, ClassTemp);
		num++;
		Debug.Log("SELECTED");
		Back();
	}
	
	public void Ready2(){
		GM.instance.SetSpell(np1, SpellName, SpellImage);
		ChosenSpell.interactable = false;
		Ready_b2.SetActive(false);
		SpellName = "";
		SpellImage = null;
		np2++; //increment spell count for the player
	}
	
	public void Ready3(){
		CameraMovement.GetComponent<Animator>().SetTrigger("Begin");
		StartMatch();
		Destroy(Character_Select_Menu);
	}
	
	public void Back(){
		Ready_b.SetActive(false);
		DescriptionClear(Description_b.transform.childCount);
	}
	
	public void Undo(){
		GM.instance.UndoPlayer(num);
		num--;
	}
	
	//UI Description
	private void Description(int total){
		for(int i = 0; i < total; i++){
			if(_spellDescription == 1){
				if("Spell" == Description_b.transform.GetChild(i).tag){
					Description_b.transform.GetChild(i).gameObject.SetActive(true);
				} else {
					Description_b.transform.GetChild(i).gameObject.SetActive(false);
				}
			} else {
				if(ClassTemp.tag == Description_b.transform.GetChild(i).tag){
					Description_b.transform.GetChild(i).gameObject.SetActive(true);
				} else {
					Description_b.transform.GetChild(i).gameObject.SetActive(false);
				}
			}
		}
	}
	
	private void DescriptionClear(int total){
		for(int i = 0; i < total; i++){
			Description_b.transform.GetChild(i).gameObject.SetActive(false);
		}
	}
}