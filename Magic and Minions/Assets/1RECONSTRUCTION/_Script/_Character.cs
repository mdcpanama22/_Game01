using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Character : MonoBehaviour {

    public int HP;
    public int MAX_HP;
    public int DMG;
    public int Mana;
    public int Cost;
    public int AMOUT_OF_TIME_ALIVE;

    public int Movement_c; //AMOUNT OF TIMES THEY CAN MOVE
    public int Attack_c;  //AMOUNT OF TIMES THEY CAN ATTACK

    public int Moves;//Amount of times moved/attacked
    public int Attacks;

    private GameObject _CurrentPosition;
    // Use this for initialization
    void Start () {
        _CurrentPosition = null;
        if (this.tag == "Paladin") { Mana = 7; }
        else if (this.tag == "Necro") { Mana = 5; }
        if (this.tag == "Wraith" || this.tag == "Skeleton" || this.tag == "GreatSpirit")
        {
            AMOUT_OF_TIME_ALIVE = 0;
        }
        else
        {
            AMOUT_OF_TIME_ALIVE = 1;
        }
        if(GetComponent<Type>().ChosenCharacterType == Type.CharacterType.Magician)
        {
            Moves = 0;
            Attacks = 0;
        }
        else
        {
            Moves = Movement_c;
            Attacks = Attack_c;
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseOver()
    {
        if (_CurrentPosition != null)
            if (_CurrentPosition.gameObject.GetComponent<SphereCollider>().enabled)
                _CurrentPosition.gameObject.GetComponent<MeshRenderer>().material.color = GM.instance.ChangeSquareColor(_CurrentPosition.gameObject.GetComponent<_OnMouseSquare>()._originalColor);
    }
    void OnMouseExit()
    {
        _CurrentPosition.gameObject.GetComponent<MeshRenderer>().material.color = _CurrentPosition.gameObject.GetComponent<_OnMouseSquare>()._originalColor;
    }

    void OnCollisionEnter(Collision col)
    {
        _CurrentPosition = col.gameObject;

    }
    void OnCollisionExit(Collision col)
    {
        _CurrentPosition = null;
    }

}
