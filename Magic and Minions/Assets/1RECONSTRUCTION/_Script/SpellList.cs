//original file by matt
//used by EventSystem
//used for Containing a list of all spells and their definitions



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum SpellTypes
{
	Mana,
	Shadow
}

public enum SpellRangeType
{
	/*
	 * AOE == only blocks
	 * AOE_ALL == blocks, foes, and friends
	 */
	AOE, //Different types of AOE for the attack
	CONE,
	TARGETED,
	PASSIVE
}

public enum RangeType
{
	FOE,
	FRI,
	FLO,
	ALL,
	NONE
}

public class SpellList : MonoBehaviour {
	public List<Tag> ALLSPELLS;
	
	public List<GameObject> SpellImage;
	
	public Sprite DEFAULT;
	
	public GameObject PlayerSpellUI, AbilitiesSpellUI;
	
	Spell CurrentSpell;
	
	//Each spells basic information
	//MultipleCosts will be used to determine how many types are used for cost
	public struct Spell{
		public string Name, Description;
		
		public RangeType Type; // 0 == passive 1 == active 2 == summon
		
		public int Range;// Range > 0 == Range of effect || Range == 0 == Passive || Range == -1 == Self
		
		public Sprite Spell_Image;
		
		public List<int> Costs;
		
		public List<SpellTypes> MultipleCosts;
		
		public SpellRangeType SpellRangeType;
		
		public Spell(string N, string D, RangeType T, int R, Sprite SI, List<int> Co, List<SpellTypes> MCL, SpellRangeType SRT){
			Name = N;
			Description = D;
			Type = T;
			Range = R;
			Spell_Image = SI;
			Costs = new List<int>();
			MultipleCosts = new List<SpellTypes>();
			for(int i = 0; i < Co.Count; i++){
				Costs.Add(Co[i]);
			}
			for(int i = 0; i < MCL.Count; i++){
				MultipleCosts.Add(MCL[i]);
			}
			SpellRangeType = SRT;
		}
	}
	
	public struct Tag{
		public string tag;
		public List<Spell> spell;
		public Tag(string t, List<Spell> S){
			tag = t;
			spell = S;
		}
	}
	//Range 0: self effect or an effect that only affects you 
	// Range > 0 == Range of effect || Range == 0 == Passive || Range == -1 == Self

   //BESERKER
	[Header("Drunkard Minion")]
	public List<int> Drunkard_Cost;
	
	public List<SpellTypes> Drunkard_Types;
	
	public RangeType Drunkard_State;
	
	public int Drunkard_Range;
	
	public SpellRangeType Drunkard_Range_Type;
	
	public Sprite Drunkard_Image;

	[Header("Orcish Grunt Minion")]
	
	public List<int> Orcish_Grunt_Cost;
	
	public List<SpellTypes> Orcish_Grunt_Types;
	
	public RangeType Orcish_Grunt_State;
	
	public int Orcish_Grunt_Range;
	
	public SpellRangeType Orcish_Grunt_Range_Type;
	
	public Sprite Orcish_Image;

	[Header("Mana Wisp Minion")]
	public List<int> Mana_Wisp_Cost;
	
	public List<SpellTypes> Mana_Wisp_Types;
	
	public RangeType Mana_Wisp_State;
	
	public int Mana_Wisp_Range;
	
	public SpellRangeType Mana_Wisp_Range_Type;
	
	public Sprite Mana_Wisp_Image;

	[Header("Arcane Blood Passive")]
	public List<int> Arcane_Blood_Cost;
	
	public List<SpellTypes> Arcane_Blood_Types;
	
	public RangeType Arcane_Blood_State;
	
	public int Arcane_Blood_Range;
	
	public SpellRangeType Arcane_Blood_Range_Type;
	
	public Sprite Arcane_Blood_Image;

	[Header("Bloodfury Passive")]
	public List<int> Bloodfury_Cost;
	
	public List<SpellTypes> Bloodfury_Blood_Types;
	
	public RangeType Bloodfury_State;
	
	public int Bloodfury_Range;
	
	public SpellRangeType Bloodfury_Range_Type;
	
	public Sprite Bloodfury_Image;

	[Header("Stagger Passive")]
	public List<int> Stagger_Cost;
	
	public List<SpellTypes> Stagger_Types;
	
	public RangeType Stagger_State;
	
	public int Stagger_Range;
	
	public SpellRangeType Stagger_Range_Type;
	
	public Sprite Stagger_Image;

	[Header("Superstitious Passive")]
	public List<int> Superstitious_Cost;
	
	public List<SpellTypes> Superstitious_Types;
	
	public RangeType Superstitious_State;
	
	public int Superstitious_Range;
	
	public SpellRangeType Superstitious_Range_Type;
	
	public Sprite Superstitious_Image;

	[Header("Blink Spell")]
	public List<int> Blink_Cost;
	
	public List<SpellTypes> Blink_Type;
	
	public RangeType Blink_State;
	
	public int Blink_Range;
	
	public SpellRangeType Blink_Range_Type;
	
	public Sprite Bling_Image;

	[Header("Molotov Throw Spell")]
	public List<int> Molotv_Throw_Cost;
	
	public List<SpellTypes> Molotov_Throw_Types;
	
	public RangeType Molotv_Throw_State;
	
	public int Molotv_Throw_Range;
	
	public SpellRangeType Molotv_Throw_Range_Type;
	
	public Sprite Molotv_Throw_Image;

	[Header("Drunken Cleave Spell")]
	public List<int> Drunken_Cleave_Cost;
	
	public List<SpellTypes> Drunken_Cleave_Types;
	
	public RangeType Drunken_Cleave_State;
	
	public int Drunken_Cleave_Range;
	
	public SpellRangeType Drunken_Cleave_Range_Type;
	
	public Sprite Drunken_Cleave_Image;

	[Header("Painkiller Spell")]
	public List<int> Painkiller_Cost;
	
	public List<SpellTypes> Painkiller_Types;
	
	public RangeType Painkiller_State;
	
	public int Painkiller_Range;
	
	public SpellRangeType Painkiller_Range_Type;
	
	public Sprite Painkiler_Image;

	[Header("Vicious Cleave Spell")]
	public List<int> Vicious_Cleave_Cost;
	
	public List<SpellTypes> Vicious_Cleave_Types;
	
	public RangeType Vicious_Cleave_State;
	
	public int Vicious_Cleave_Range;
	
	public SpellRangeType Vicious_Cleave_Range_Type;
	
	public Sprite Vicious_Cleave_Image;

	[Header("Vanish Spell")]
	public List<int> Vanish_Cost;
	
	public List<SpellTypes> Vanish_Types;
	
	public RangeType Vanish_State;
	
	public int Vanish_Range;
	
	public SpellRangeType Vanish_Range_Type;
	
	public Sprite Vanish_Image;

	[Header("Chug")]
	public List<int> Chug_Cost;
	
	public List<SpellTypes> Chug_Types;
	
	public RangeType Chug_State;
	
	public int Chug_Range;
	
	public SpellRangeType Chug_Range_Type;
	
	public Sprite Chug_Image;

	//NECROMANCER :: Necromancer, Spectre, Witch Doctor
	[Header("Wisp Minion")]
	public List<int> Wisp_Cost;
	
	public List<SpellTypes> Wisp_Types;
	
	public RangeType Wisp_State;
	
	public int Wisp_Range;
	
	public SpellRangeType Wisp_Range_Type;
	
	public Sprite Wisp_Image;

	[Header("Skeleton Minion")]
	public List<int> Skeleton_Cost;
	
	public List<SpellTypes> Skeleton_Types;
	
	public RangeType Skeleton_State;
	
	public int Skeleton_Range;
	
	public SpellRangeType Skeleton_Range_Type;
	
	public Sprite Skeleton_Image;

	[Header("Wraith Minion")]
	public List<int> Wraith_Cost;
	
	public List<SpellTypes> Wraith_Types;
	
	public RangeType Wraith_State;
	
	public int Wraith_Range;
	
	public SpellRangeType Wraith_Range_Type;
	
	public Sprite Wraith_Image;

	[Header("Plague Passive")]
	public List<int> Plague_Cost;
	
	public List<SpellTypes> Plague_Types;
	
	public RangeType Plague_State;
	
	public int Plague_Range;
	
	public SpellRangeType Plague_Range_Type;
	
	public Sprite Plague_Image;

	[Header("Rising Darkness Passive")]
	public List<int> Rising_Darkness_Cost;
	
	public List<SpellTypes> Rising_Darkness_Types;
	
	public RangeType Rising_Darkness_State;
	
	public int Rising_Darkness_Range;
	
	public SpellRangeType Rising_Darkness_Range_Type;
	
	public Sprite Rising_Darkness_Image;

	[Header("Essence Projection Spell")]
	public List<int> Essence_Projection_Cost;
	
	public List<SpellTypes> Essence_Projection_Types;
	
	public RangeType Essence_Projection_State;
	
	public int Essence_Projection_Range;
	
	public SpellRangeType Essence_Projection_Range_Type;
	
	public Sprite Essence_Projection_Image;

	[Header("Possession Spell")]
	public List<int> Possession_Cost;
	
	public List<SpellTypes> Possession_Types;
	
	public RangeType Possession_State;
	
	public int Possession_Range;
	
	public SpellRangeType Possession_Range_Type;
	
	public Sprite Possession_Image;

	[Header("Soul Swarm Spell")]
	public List<int> Soul_Swarm_Cost;
	
	public List<SpellTypes> Soul_Swarm_Types;
	
	public RangeType Soul_Swarm_State;
	
	public int Soul_Swarm_Range;
	
	public SpellRangeType Soul_Swarm_Range_Type;
	
	public Sprite Soul_Swarm_Image;

	[Header("Soul Inhale Spell")]
	public List<int> Soul_Inhale_Cost;
	
	public List<SpellTypes> Soul_Inhale_Types;
	
	public RangeType Soul_Inhale_State;
	
	public int Soul_Inhale_Range;
	
	public SpellRangeType Soul_Inhale_Range_Type;
	
	public Sprite Soul_Inhale_Image;

	[Header("Soul Rot Spell")]
	public List<int> Soul_Rot_Cost;
	
	public List<SpellTypes> Soul_Rot_Types;
	
	public RangeType Soul_Rot_State;
	
	public int Soul_Rot_Range;
	
	public SpellRangeType Soul_Rot_Range_Type;
	
	public Sprite Soul_Rot_Image;

	[Header("Dark Monolith Spell")]
	public List<int> Dark_Monolith_Cost;
	
	public List<SpellTypes> Dark_Monolith_Types;
	
	public RangeType Dark_Monolith_State;
	
	public int Dark_Monolith_Range;
	
	public SpellRangeType Dark_Monolith_Range_Type;
	
	public Sprite Dark_Monolith_Image;

	[Header("Energy Sling Spell")]
	public List<int> Energy_Sling_Cost;
	
	public List<SpellTypes> Energy_Sling_Types;
	
	public RangeType Energy_Sling_State;
	
	public int Energy_Sling_Range;
	
	public SpellRangeType Energy_Sling_Range_Type;
	
	public Sprite Energy_Sling_Image;

	//Universal

	public string SpellTemp;
	private List<GameObject> Spaces;
	// Use this for initialization
	private void Awake(){
		PlayerSpellUI.GetComponent<CanvasGroup>().alpha = 0;
		Spaces = new List<GameObject>();
		CurrentSpell = new Spell();
	}
	void Start(){
		ALLSPELLS = new List<Tag>();
		//Beserker					
		List<Spell> Beserker = new List<Spell>();

		//Drunkard Minion
		Beserker.Add(new Spell("Drunkard", "Summon a 2 Damage, 4 Health Drunkard, for 2 Mana", Drunkard_State, Drunkard_Range, DEFAULT, Drunkard_Cost, Drunkard_Types, Drunkard_Range_Type));

		//Orcish Grunt Minion
		Beserker.Add(new Spell("Orcish_Grunt", "Summon a 2 Damage, 3 Health Orcish Grunt, for 3 Mana. Can attack twice", Orcish_Grunt_State, Orcish_Grunt_Range, DEFAULT, Orcish_Grunt_Cost, Orcish_Grunt_Types, Orcish_Grunt_Range_Type));

		//Mana Wisp Minion
		Beserker.Add(new Spell("Mana_Wisp", "Summon a 1 Damage, 3 Health Mana Wisp, for 5 Mana. Gain 1 mana at the end of your turn", Mana_Wisp_State, Mana_Wisp_Range, DEFAULT, Mana_Wisp_Cost, Mana_Wisp_Types, Mana_Wisp_Range_Type));

		//Blink Spell
		Beserker.Add(new Spell("Blink", "Teleport 1 + (rage) spaces, for 3 Mana", Blink_State, Blink_Range, DEFAULT, Blink_Cost, Blink_Type, Blink_Range_Type));

		//Molotov Throw Spell
		Beserker.Add(new Spell("Molotov_Throw", "Deal 4 damage to target space within a range of 2, dealing 4 damage to chosen space, and 1 to the spaces around, for 5 Mana", Molotv_Throw_State, Molotv_Throw_Range, DEFAULT, Molotv_Throw_Cost, Molotov_Throw_Types, Molotv_Throw_Range_Type));

		/*
		 *	P A S S I V E S
		 */
		//Arcane Blood Passive
		Beserker.Add(new Spell("Arcane_Blood", "Berserker gains 1 mana after each melee attack, and after every time Berserker moves, deal 1 damage to up to 2 adjacent units", Arcane_Blood_State, Arcane_Blood_Range, DEFAULT, Arcane_Blood_Cost, Arcane_Blood_Types, Arcane_Blood_Range_Type));
			
		//Bloodfury Passive
		Beserker.Add(new Spell("Bloodfury", "Bloodfury, gain 1 rage for every kill your hero makes with melee attacks or spells", Bloodfury_State, Bloodfury_Range, DEFAULT, Bloodfury_Cost, Bloodfury_Blood_Types, Bloodfury_Range_Type));
			
		//Bloodfury Passive
		Beserker.Add(new Spell("Stagger", "Stagger, ever time you cast a spell, you must stagger 1 space before casting", Stagger_State, Stagger_Range, DEFAULT, Stagger_Cost, Stagger_Types, Stagger_Range_Type));
			
		//Superstitious Passive
		Beserker.Add(new Spell("Superstitious", "Heal 2 health when targeted by any spell", Superstitious_State, Superstitious_Range, DEFAULT, Superstitious_Cost, Superstitious_Types, Superstitious_Range_Type));
		
		//Chug
		Beserker.Add(new Spell("Chug", "Gain 4 Mana or 1 Rage, but no longer can take an action", Chug_State, Chug_Range, DEFAULT, Chug_Cost, Chug_Types, Chug_Range_Type));
			
		//Drunken Cleave Spell
		Beserker.Add(new Spell("Drunken_Cleave", "Stagger 2 spaces, then deal 3 damage to 2 continious adjacent spaces, for 4 Mana", Drunken_Cleave_State, Drunken_Cleave_Range, DEFAULT, Drunken_Cleave_Cost, Drunken_Cleave_Types, Drunken_Cleave_Range_Type));

		//Painkiller Spell
		Beserker.Add(new Spell("Painkiller", "Restore 4 hp to Berserker, for 4 mana or 1 rage", Painkiller_State, Painkiller_Range, DEFAULT, Painkiller_Cost, Painkiller_Types, Painkiller_Range_Type));
			
		//Vicious Cleave Spell
		Beserker.Add(new Spell("Vicious_Cleave", "Deal 6 damage to two adjacent units, and gain one rage per kill, for 7 Mana or 5 Rage", Vicious_Cleave_State, Vicious_Cleave_Range, DEFAULT, Vicious_Cleave_Cost, Vicious_Cleave_Types, Vicious_Cleave_Range_Type));

		//Vanish Spell
		Beserker.Add(new Spell("Vanish", "Teleport to a square 3 spaces away, for 1 essence", Vanish_State, Vanish_Range, DEFAULT,Vanish_Cost, Vanish_Types, Vanish_Range_Type));






		/* 
		 * N e c r o m a n c e r 
		 */
		List<Spell> Necromancer = new List<Spell>();
		
		//Wisp
		Necromancer.Add( new Spell("Wisp", "Summon 1 damage, 2 health Wisp with 2 moves, for 1 Mana", Wisp_State, Wisp_Range, DEFAULT, Wisp_Cost, Mana_Wisp_Types, Mana_Wisp_Range_Type));
		
		//Skeleton
		Necromancer.Add(new Spell("Skeleton", "Summon 3 damage, 2 health Skeleton, for 2 Mana", Skeleton_State, Skeleton_Range, DEFAULT, Skeleton_Cost, Skeleton_Types, Skeleton_Range_Type));

		//Wraith
		Necromancer.Add(new Spell("Wraith", "Summon 3 damage, 4 health Wraith, for 3 Mana", Wraith_State, Wraith_Range, DEFAULT, Wraith_Cost, Wraith_Types, Wraith_Range_Type));

		//Plague
		Necromancer.Add(new Spell("Plague", "Minions that you kill rise again as zombies and have damage and hp reduced by 50%", Plague_State, Plague_Range, DEFAULT, Plague_Cost, Plague_Types, Plague_Range_Type));

		//Rising Darkness
		Necromancer.Add(new Spell("Rising_Darkness", "Rising Darkness, friendly zombies gain + 1/4 damage and + 1/2 hp for each shadow Necromancer has when they rise", Rising_Darkness_State, Rising_Darkness_Range, DEFAULT, Rising_Darkness_Cost, Rising_Darkness_Types, Rising_Darkness_Range_Type));

		//Possession
		Necromancer.Add(new Spell("Possession", "Pay life equal to a minion’s hp to take control of it, for 2 Mana", Possession_State, Possession_Range, DEFAULT, Possession_Cost, Possession_Types, Possession_Range_Type));

		//Soul Swarm
		Necromancer.Add(new Spell("Soul_Swarm", "Summon 4 wisps adjacent to the Necromancer and deal 3 damage to the Necromancer", Soul_Swarm_State, Soul_Swarm_Range, DEFAULT, Soul_Swarm_Cost, Soul_Swarm_Types, Soul_Swarm_Range_Type));

		//Soul Inhale
		Necromancer.Add(new Spell("Soul_Inhale", "Deal 2 damage in a right cone of radius 2, heal Necromancer for half damage dealt", Soul_Inhale_State, Soul_Inhale_Range, DEFAULT, Soul_Inhale_Cost, Soul_Inhale_Types, Soul_Inhale_Range_Type));

		//Dark Monolith
		Necromancer.Add(new Spell("Dark_Monolith", "Place a 5 health, monolith which generates 1 shadow for the Necromancer each turn", Dark_Monolith_State, Dark_Monolith_Range, DEFAULT, Dark_Monolith_Cost, Dark_Monolith_Types, Dark_Monolith_Range_Type));

		//Energy Sling
		Necromancer.Add(new Spell("Energy_Sling", "Kill a friendly minion to teleport up to its hp in spaces away", Energy_Sling_State, Energy_Sling_Range, DEFAULT, Energy_Sling_Cost, Energy_Sling_Types, Energy_Sling_Range_Type));

		//Essence Projection
		Necromancer.Add(new Spell("Essence_Projection", "Destroy a friendly minion to deal its damage to one target within 2 spaces of it, for 2 mana or 1 shadow", Essence_Projection_State, Essence_Projection_Range, DEFAULT, Essence_Projection_Cost, Essence_Projection_Types, Essence_Projection_Range_Type));

		//Soul Rot
		Necromancer.Add(new Spell("Soul_Rot", "Deal 4 damage to target and 2 to Necromancer", Soul_Rot_State, Soul_Rot_Range, DEFAULT, Soul_Rot_Cost, Soul_Rot_Types, Soul_Inhale_Range_Type));


		//The first parameter is based on the actual tag on the gameobject in unity
		Tag B = new Tag("Beserker", Beserker);
		Tag N = new Tag("Necro", Necromancer);

		ALLSPELLS.Add(B);
		ALLSPELLS.Add(N);
	}

	private int clicked = 0;
	//Used to reset clicked variable for choosing character to interact with
	public void ClickedButton(){
		clicked = 0;
	}

	// Update is called once per frame
	void Update(){
		if(GM.instance.GetAmountofPlayers() != -1 ){
			int player = GM.instance.turn % GM.instance.GetAmountofPlayers();
			int layer_mask = LayerMask.GetMask("Player1");
			if(PlayerSpellUI.GetComponent<CanvasGroup>().alpha == 1){
				layer_mask = LayerMask.GetMask("UI");
			}
			switch(player){
				case 1:
					layer_mask = LayerMask.GetMask("Player2");
					break;
				case 2:
					layer_mask = LayerMask.GetMask("Player3");
					break;
				case 3:
					layer_mask = LayerMask.GetMask("Player4");
					break;
				case 4:
					layer_mask = LayerMask.GetMask("Player5");
					break;
				case 5:
					layer_mask = LayerMask.GetMask("Player6");
					break;
				case 6:
					layer_mask = LayerMask.GetMask("Player7");
					break;
				case 7:
					layer_mask = LayerMask.GetMask("Player8");
					break;
			}

			RaycastHit hitInfo = new RaycastHit();
			if(!GM.instance.SPELLCASTING){
				if(layer_mask != LayerMask.GetMask("UI")){
					if(Input.GetMouseButton(0)){
						if(Physics.Raycast(GM.instance.First.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, layer_mask)){
							clicked = 1;
							GM.instance.CurrentObject = hitInfo.collider.transform.gameObject;
							ShowSpells(player, hitInfo.collider.transform.gameObject.GetComponent<Type>().ChosenCharacterType);
							RelocateSpellUI(hitInfo.collider.transform.gameObject);
							PlayerSpellUI.SetActive(true);
							PlayerSpellUI.GetComponent<CanvasGroup>().alpha = 1f;

							foreach(Button B in PlayerSpellUI.GetComponentsInChildren<Button>()){
								B.interactable = true;
							}
						} else {
							ResetPlayerSpellsUI();
						}
					} else {
						if(clicked != 1){
							if(Physics.Raycast(GM.instance.First.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, layer_mask)){
								GM.instance.CurrentObject = hitInfo.collider.transform.gameObject;
								ShowSpells(player, hitInfo.collider.transform.gameObject.GetComponent<Type>().ChosenCharacterType);
								RelocateSpellUI(hitInfo.collider.transform.gameObject);
								PlayerSpellUI.SetActive(true);
								PlayerSpellUI.GetComponent<CanvasGroup>().alpha = 0.4f;
							}
						}
					}
				} else {
					if(Input.GetMouseButton(0)){
						if(Physics.Raycast(GM.instance.First.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity)){
							GameObject currentClicked = hitInfo.collider.transform.gameObject;
							if(!(EventSystem.current.IsPointerOverGameObject())){ //Works for when the mouse is over a UI element with something behind it. I said ! so that it consider situations when you don't click the UI
								if(currentClicked.layer != layer_mask && hitInfo.collider.transform.gameObject != GM.instance.CurrentObject){
									ResetPlayerSpellsUI();
								}
							}
						}
					}
				}
			} else { //WHILE SPELLCASTING
				RangeType RT = CurrentSpell.Type;
				if(Input.GetMouseButton(0)){
					if(Physics.Raycast(GM.instance.First.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity)){
						if(hitInfo.collider.transform.gameObject.tag != "UI"){
							if(RT == RangeType.ALL){
								for(int i = 0; i < GM.instance.GetAmountofPlayers(); i++){
									string tags = "Player" + i.ToString();
								}
							}
							GM.instance.UnshowShow();
						}
					}
				}
			}
		}
	}
	
	public void RelocateSpellUI(GameObject RSUI){
		Vector3 namePos = Camera.main.WorldToScreenPoint(RSUI.transform.position);
		PlayerSpellUI.transform.position = namePos;
	}
	
	public void ShowSpells(int p, Type.CharacterType currentCharacterType){
		// ||PASSIVES || MINIONS || SPELLS || \\
		if (Type.CharacterType.Magician == currentCharacterType)
		{
			int i = 0;
			foreach(Transform X in AbilitiesSpellUI.transform){
			   if(i < GM.instance.Players[p].Spells.Count){
					X.GetComponent<Image>().sprite = GM.instance.Players[p].Spells[i].SpellImage;
					X.GetComponent<Spell_button_identifier>().CURRENT_SPELL = GM.instance.Players[p].Spells[i].SpellName;
					i++;
				}
			}
		}
	}

	public void SpellEffect(GameObject current){
		Spaces.Clear();
		CurrentSpell = new Spell();
		if(current.name == "Move"){
			CurrentSpell.Name = "Move";
			CurrentSpell.Type = RangeType.FLO;
			CurrentSpell.SpellRangeType = SpellRangeType.AOE;
		} else if(current.name == "Attack"){
			CurrentSpell.Name = "Attack";
			CurrentSpell.Type = RangeType.ALL;
			CurrentSpell.SpellRangeType = SpellRangeType.AOE;
		} else {
			SpellTemp = current.GetComponent<Spell_button_identifier>().CURRENT_SPELL;
			Debug.Log(SpellTemp + " WAS SELECTED");
			CurrentSpell = FindSpell(SpellTemp);
		}
		ResetPlayerSpellsUI();
		GM.instance._CurrentSpell = CurrentSpell;
		if(CurrentSpell.Name != ""){
			GM.instance.AOE(CurrentSpell.Type, CurrentSpell);
			GM.instance.UnshowShow();
		}
	}
	
	public void ResetPlayerSpellsUI(){
		PlayerSpellUI.SetActive(false);
		PlayerSpellUI.GetComponent<CanvasGroup>().alpha = 0.4f;
		foreach(Button B in PlayerSpellUI.GetComponentsInChildren<Button>()){
			B.interactable = false;
		}
		clicked = 0;
	}
	
	public Spell FindSpell(string currentSpellName){
		foreach(Tag X in ALLSPELLS){
			foreach(Spell S in X.spell){
				if(S.Name == currentSpellName){
					return S;
				}
			}
		}
		return new Spell();
	}
}