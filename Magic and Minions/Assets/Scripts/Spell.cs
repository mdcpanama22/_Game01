//Original File by Ben
//used by Unknown
//used for holding information about a spell.

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Spell {
	public BoardObject owner;
	public string name, description;
	public int[] cost;
	public string[] effects;
	public bool passive;
	
	public void Print(){
		Debug.Log("Name: " + name + " Descrip: " + description);
	}
	
	public virtual Action Cast(){
		Print();
		return new Action();
	}
	
	public virtual Action AutoCast(){
		Print();
		return new Action();
	}
}

//necromancer
////minions
public class DarkMonolith : Spell{
	
	public DarkMonolith(BoardObject bo){
		owner = bo;
		name = "Dark Monolith";
		description = "Place a 5 health, monolith which generates 1 shadow for the Necromancer each turn";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,0,0,0,0};
	}
	
	public override Action Cast(){
		BoardObject bo = GameObject.FindWithTag("Board").GetComponent<BoardManager>().targetedBoardObject;
		bo.BuildDarkMonolith();
		return new Summon(bo);
	}
}

public class Skeleton : Spell{
	
	public Skeleton(BoardObject bo){
		owner = bo;
		name = "Skeleton";
		description = "Summon 3 damage, 2 health Skeleton, for 2 Mana";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,2,0,0,0};
	}
	
	public override Action Cast(){
		BoardObject bo = GameObject.FindWithTag("Board").GetComponent<BoardManager>().targetedBoardObject;
		bo.BuildSkeleton();
		return new Summon(bo);
	}
}

public class Wisp : Spell{
	
	public Wisp(BoardObject bo){
		owner = bo;
		name = "Wisp";
		description = "Summon 1 damage, 2 health Wisp with 2 moves, for 1 Mana";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,1,0,0,0};
	}
	
	public override Action Cast(){
		BoardObject bo = GameObject.FindWithTag("Board").GetComponent<BoardManager>().targetedBoardObject;
		bo.BuildWisp();
		return new Summon(bo);
	}
}

public class Wraith : Spell{
	
	public Wraith(BoardObject bo){
		owner = bo;
		name = "Wraith";
		description = "Summon 3 damage, 4 health Wraith, for 3 Mana";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,3,0,0,0};
	}
	
	public override Action Cast(){
		BoardObject bo = GameObject.FindWithTag("Board").GetComponent<BoardManager>().targetedBoardObject;
		bo.BuildWraith();
		return new Action();
	}
}

////spells
public class EnergySling : Spell{
	
	public EnergySling(BoardObject bo){
		owner = bo;;
		name = "Energy Sling";
		description = "Kill a friendly minion to teleport up to its hp in spaces away";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,0,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class EssenceProjection : Spell{
	
	public EssenceProjection(BoardObject bo){
		owner = bo;
		name = "Essence Projection";
		description = "Destroy a friendly minion to deal its damage to one target within 2 spaces of it, for 2 mana or 1 shadow";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,0,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class Possession : Spell{
	
	public Possession(BoardObject bo){
		owner = bo;
		name = "Possession";
		description = "Pay life equal to a minion’s hp to take control of it, for 2 Mana";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,2,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class SoulInhale : Spell{
	
	public SoulInhale(BoardObject bo){
		owner = bo;
		name = "Soul Inhale";
		description = "Deal 2 damage in a right cone of radius 2, heal Necromancer for half damage dealt";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,0,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class SoulRot : Spell{
	
	public SoulRot(BoardObject bo){
		owner = bo;
		name = "Soul Rot";
		description = "Deal 4 damage to target and 2 to Necromancer";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{2,0,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class SoulSwarm : Spell{
	
	public SoulSwarm(BoardObject bo){
		owner = bo;
		name = "Soul Swarm";
		description = "Summon 4 wisps adjacent to the Necromancer and deal 3 damage to the Necromancer";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{3,0,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

////passives
public class Plague : Spell{
	
	public Plague(BoardObject bo){
		owner = bo;
		name = "Plague";
		description = "Minions that you kill rise again as zombies and have damage and hp reduced by 50%";
		passive = true;
	}
	
	public override Action AutoCast(){
		return new Action();
	}
}

public class RisingDarkness : Spell{
	
	public RisingDarkness(BoardObject bo){
		owner = bo;
		name = "Rising Darkness";
		description = "Rising Darkness, friendly zombies gain + 1/4 damage and + 1/2 hp for each shadow Necromancer has when they rise";
		passive = true;
	}
	
	public override Action AutoCast(){
		return new Action();
	}
}

//Barbarian
////Minions
public class Drunkard : Spell{
	
	public Drunkard(BoardObject bo){
		owner = bo;
		name = "Drunkard";
		description = "Summon a 2 Damage, 4 Health Drunkard, for 2 Mana";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,2,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class ManaWisp : Spell{
	
	public ManaWisp(BoardObject bo){
		owner = bo;
		name = "Mana Wisp";
		description = "Summon a 1 Damage, 3 Health Mana Wisp, for 5 Mana. Gain 1 mana at the end of your turn";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,5,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class OrcishGrunt : Spell{
	
	public OrcishGrunt(BoardObject bo){
		owner = bo;
		name = "Orcish Grunt";
		description = "Summon a 2 Damage, 3 Health Orcish Grunt, for 3 Mana. Can attack twice";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,3,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

////spells
public class Blink : Spell{
	
	public Blink(){
		name = "Blink";
		description = "Teleport 1 + (rage) spaces, for 3 Mana";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,3,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class Chug : Spell{
	
	public Chug(){
		name = "Chug";
		description = "Gain 4 Mana or 1 Rage, but no longer can take an action";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,0,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class DrunkenCleave : Spell{
	
	public DrunkenCleave(){
		name = "Drunken Cleave";
		description = "Stagger 2 spaces, then deal 3 damage to 2 continious adjacent spaces, for 4 Mana";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,0,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class MolotovThrow : Spell{
	
	public MolotovThrow(){
		name = "Molotov Throw";
		description = "Deal 4 damage to target space within a range of 2, dealing 4 damage to chosen space, and 1 to the spaces around, for 5 Mana";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,0,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class Painkiller : Spell{
	
	public Painkiller(){
		name = "Painkiller";
		description = "Restore 4 hp to Berserker, for 4 mana or 1 rage";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,0,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class Vanish : Spell{
	
	public Vanish(){
		name = "Vanish";
		description = "Teleport to a square 3 spaces away, for 1 essence";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,0,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}

public class ViciousCleave : Spell{
	
	public ViciousCleave(){
		name = "Vicious Cleave";
		description = "Deal 6 damage to two adjacent units, and gain one rage per kill, for 7 Mana or 5 Rage";
		//{health,mana,shadow,rage,essence}
		cost = new int[]{0,0,0,0,0};
	}
	
	public override Action Cast(){
		return new Action();
	}
}
////passives
public class ArcaneBlood : Spell{
	
	public ArcaneBlood(){
		name = "Arcane Blood";
		description = "Berserker gains 1 mana after each melee attack, and after every time Berserker moves, deal 1 damage to up to 2 adjacent units";
		passive = true;
	}
	
	public override Action AutoCast(){
		return new Action();
	}
}

public class Bloodfury : Spell{
	
	public Bloodfury(){
		name = "Bloodfury";
		description = "gain 1 rage for every kill your hero makes with melee attacks or spells";
		passive = true;
	}
	
	public override Action AutoCast(){
		return new Action();
	}
}

public class Stagger : Spell{
	
	public Stagger(){
		name = "Stagger";
		description = "Stagger, ever time you cast a spell, you must stagger 1 space before casting";
		passive = true;
	}
	
	public override Action AutoCast(){
		return new Action();
	}
}

public class Superstitious : Spell{
	
	public Superstitious(){
		name = "Superstitious";
		description = "Heal 2 health when targeted by any spell";
		passive = true;
	}
	
	public override Action AutoCast(){
		return new Action();
	}
}