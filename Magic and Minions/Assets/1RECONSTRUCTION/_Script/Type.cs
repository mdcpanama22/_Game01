﻿//original file by matt
//used by unknown
//used for unknown



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type : MonoBehaviour {
    public enum CharacterType
    {
        Magician, 
		Minion
    };
    public GameObject Location;
    public Coordinates LocationCoords;
    public CharacterType ChosenCharacterType;
}
