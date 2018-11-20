//original file by matt
//used by unknown
//used for unknown



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana_Life_Updater : MonoBehaviour {

	public GameObject Mana, Life;
	
	public Text ManaText, LifeText;
	
	// Use this for initialization
	void Start(){
		Mana = transform.Find("Mana").gameObject;
		Life = transform.Find("Life").gameObject;

		ManaText = Mana.transform.Find("Mana_Amount").GetComponent<Text>();
		LifeText = Life.transform.Find("Life_Amount").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update(){
		if(GM.instance.CurrentObject != null){
			if(GM.instance.CurrentObject.GetComponent<Type>().ChosenCharacterType == Type.CharacterType.Magician){
				gameObject.SetActive(true);
				ManaText.text = GM.instance.CurrentObject.GetComponent<_Character>().Mana.ToString();
			} else if(GM.instance.CurrentObject.GetComponent<Type>().ChosenCharacterType == Type.CharacterType.Minion){
				gameObject.SetActive(false);
				ManaText.text = "";
			}
			LifeText.text = GM.instance.CurrentObject.GetComponent<_Character>().HP.ToString();
		}
	}
}
