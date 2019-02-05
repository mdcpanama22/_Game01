//Author: Ben Eid
//Description: Manager class for the Character/Spell selection page. Manages Which UI elements to display, the content of those elements, and scene transitions.



using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionUI : MonoBehaviour {
	public GameObject characterSelect, spellSelect, boardActorPrefab, characterSelectConfirmButton, spellSelectConfirmButton, previewText;
	
	//Reads the characters file and activates a character select menu with that data. Then ensures that the spell select menu with it's button are not active.
	void Start(){
		characterSelect.SetActive(true);
		characterSelectConfirmButton.SetActive(true);
		spellSelect.SetActive(false);
		spellSelectConfirmButton.SetActive(false);
		characterSelect.GetComponent<CharacterSelect>().Initialize(ReadFile("Assets/Resources/characters.txt", '\n'));
	}
	
	//Run when the player confirms their selected character. Generates a spell select with the appropiate spells.
	public void ConfirmCharacterSelect(){
		string characterName = characterSelect.GetComponent<CharacterSelect>().potentialCharacterName;
		GameObject newBoardActor = Instantiate(boardActorPrefab) as GameObject;
		BoardObject newBoardObject = newBoardActor.GetComponent<BoardObject>();
		newBoardObject.InitializeAsPlayer(characterName);
		List<Spell> spellBook = new List<Spell>();
		switch(characterName){
			case "NECROMANCER":
				spellBook.Add(new Wisp(newBoardObject));
				spellBook.Add(new Skeleton(newBoardObject));
				spellBook.Add(new Wraith(newBoardObject));
				spellBook.Add(new Possession(newBoardObject));
				spellBook.Add(new SoulSwarm(newBoardObject));
				spellBook.Add(new SoulInhale(newBoardObject));
				spellBook.Add(new DarkMonolith(newBoardObject));
				spellBook.Add(new EnergySling(newBoardObject));
				spellBook.Add(new EssenceProjection(newBoardObject));
				spellBook.Add(new SoulRot(newBoardObject));
				spellBook.Add(new Plague(newBoardObject));
				spellBook.Add(new RisingDarkness(newBoardObject));
				break;
			default:
				break;
		}
		spellSelect.GetComponent<SpellSelect>().Initialize(spellBook);
		characterSelect.SetActive(false);
		characterSelectConfirmButton.SetActive(false);
		spellSelect.SetActive(true);
		spellSelectConfirmButton.SetActive(true);
	}
	
	//Switches scenes to the game board. Run when a character and all of its spells have been selected.
	public void ConfirmSpellSelect(){
		SceneManager.LoadScene("Ben_Build_GameBoard");
	}
	
	//Updates the text in the preview text box
	public void ReceivePreviewText(string str){
		previewText.GetComponent<Text>().text = str;
	}
	//reads a file to a string, broken up by the split char (frequently newline character)
	private string[] ReadFile(string path, char split){
		StreamReader reader = new StreamReader(path); 
        string[] data = (reader.ReadToEnd()).Split(split);
        reader.Close();
		return data;
	}
}