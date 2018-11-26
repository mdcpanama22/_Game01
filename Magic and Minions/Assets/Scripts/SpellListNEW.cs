//original file by Ben
//used by unknown
//used for holding a list of all spells

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class SpellListNew : MonoBehaviour {
	private List<SpellNew> spells;
	
	// Use this for initialization
	void Start () {
		string[] fileData = ReadFile("Assets/Resources/Spells.txt", '\n');
		string[] spellData = new string[0];
		for(int i=0; i<fileData.Length; i++){
			if(fileData[i][0]!='/' || fileData[i][1]!='/'){
				spellData = fileData[i].Split('-');
				spells.Add(new SpellNew(spellData[0], spellData[1], spellData[2].Split(','), spellData[3].Split(',')));
			}
		}
	}
	
	//returns a string[] from the file which is split by a defined characer.
	private string[] ReadFile(string path, char split){
		StreamReader reader = new StreamReader(path); 
        string[] data = (reader.ReadToEnd()).Split(split);
        reader.Close();
		return data;
	}
}