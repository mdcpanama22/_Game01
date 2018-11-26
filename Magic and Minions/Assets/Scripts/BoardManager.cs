using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BoardManager : MonoBehaviour {
	public Queue<string> actionsToBeDone;
	
	private string[] nextAction;
	
	public delegate void BoardAct(int x, int y, int n);
	
	Dictionary<string, BoardAct> actions = new Dictionary<string, BoardAct>{
    {"Damage", Damage}, {"Heal", Heal}, {"Push", Push}, {"Armor", Summon}, {"Gain", Gain}
	};
	
	private void CallDelegate(string s){
		actions[s].Invoke(Int32.Parse(nextAction[1]), Int32.Parse(nextAction[2]), Int32.Parse(nextAction[3]));
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		nextAction = actionsToBeDone.Dequeue().Split('/');
	}
	
	private static void Damage(int x, int y, int n){
		
	}
	
	private static void Heal(int x, int y, int n){
		
	}
	
	private static void Push(int x, int y, int n){
		
	}
	
	private static void Armor(int x, int y, int n){
		
	}
	
	private static void Summon(int x, int y, int n){
		
	}
	
	private static void Gain(int x, int y, int n){
		
	}
}