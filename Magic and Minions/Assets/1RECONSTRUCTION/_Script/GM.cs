using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * How to add a class:
 * TO BE MADE
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
public struct Coordinates
{
    public int ID, status, Team;
    public GameObject G, location;
    public Coordinates(int ID1, int S, int TEAM, GameObject G1, GameObject L1)
    {
        Team = TEAM;
        ID = ID1;
        status = S;
        G = G1;
        location = L1;
    }
}
public struct Spell
{
    public RangeType Type; // 0 == passive 1 == active 2 == summon
    public string SpellName;
    public Sprite SpellImage;
    public Spell(RangeType T, string I, Sprite SI)
    {
        Type = T;
        SpellName = I;
        SpellImage = SI;
    }
}
public struct PlayableC
{
    public int SpellTotal;
    public List<GameObject> Minions;
    public List<Spell> Spells;
    public GameObject Character;

    public PlayableC (int ST, List<GameObject> M, List<Spell> S, GameObject C)
    {
        SpellTotal = ST;
        Spells = S;
        Minions = M;
        Character = C;
    }

}
public struct SpellButtons
{
    public string ClassName;
    public List<Button> Buttons;

    public SpellButtons(string CN, List<Button> B)
    {
        ClassName = CN;
        Buttons = B;
    }
}
public class GM : MonoBehaviour
{
    public static GM instance = null;

    public int turn = 0;
    public GameObject First;
    public int x = 8;
    private int AmountofPlayers = -1;
    public List<List<Coordinates>> Coords;
    public List<List<GameObject>> locations;

    public List<PlayableC> Players;
    public GameObject Player;

    public List<Spell> ICS; //List of Spells
    public List<Spell> ICS2; //List of Spells

    public Material[] Pedestal_Color;
    public Material[] Square_Color;

    public GameObject EventSystem;

    //Buttons for each class
    public List<Button> NecromancerButtons;
    public List<Button> BeserkerButtons;

    public List<SpellButtons> SpellButtons_;
    //Obtained when code starts
    public GameObject CurrentObject;
    public SpellList.Spell _CurrentSpell;

    public GameObject PLAYERLIST;
    public List<GameObject> Spaces;

    public bool SPELLCASTING;

    public int GetAmountofPlayers()
    {
        return AmountofPlayers;
    }
    /* intializes the Global Script*/

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }



    public List<List<GameObject>> InitializeLocations(GameObject p)
    {
        Transform[] children = p.GetComponentsInChildren<Transform>();
        List<List<GameObject>> l = new List<List<GameObject>>();
        for (int i = 0; i < x; i++)
        {
            l.Add(new List<GameObject>());
        }
        int k = 1;
        ParticleSystem pr;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                l[i].Add(children[k].gameObject);
                pr = children[k].GetComponent<ParticleSystem>();
                var main = pr.main;
                pr.Stop();
                k++;
            }
        }
        return l;
    }

    // Use this for initialization
    void Start()
    {
        SPELLCASTING = false;
        Spaces = new List<GameObject>();
        Players = new List<PlayableC>();
        locations = InitializeLocations(GameObject.Find("Grid_Board"));

        Coords = new List<List<Coordinates>>();
        Coordinates Coord;
        for (int i = 0; i < x; i++)
        {
            Coords.Add(new List<Coordinates>());
        }
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                Coord = new Coordinates(-1, 0, -1, null, locations[i][j]);
                Coords[i].Add(Coord);
            }
        }
        //LIST OF BUTTONS :: THESE ARE PRESET IN UNITY
        SpellButtons_ = new List<SpellButtons>();
        //List of Classes
        SpellButtons NecroButtons = new SpellButtons("Necromancer", NecromancerButtons);
        SpellButtons BeserkerButtons_ = new SpellButtons("Beserker", BeserkerButtons);

        //Add to List
        SpellButtons_.Add(NecroButtons);
        SpellButtons_.Add(BeserkerButtons_);

    }

    // Update is called once per frame
    void Update()
    {

    }
    //SET

    //PLAYER
    public void SetAmountofPlayers(int p)
    {
        AmountofPlayers = p;
    }
    public void SetPlayer(int p, GameObject P)
    {

        GameObject new_p = Coords[0][0].location;
        Coordinates CoorTemp = Coords[0][0];
        GameObject StartingC = P;
        StartingC.transform.localScale = new Vector3(5F, 5F, 5F);
        StartingC.transform.GetChild(0).GetComponent<MeshRenderer>().material = Pedestal_Color[p];
        int i = 0;
        int j = 0;
        if (p == 0)
        {
            CoorTemp = Coords[i][j];
            new_p = Coords[i][j].location;
            StartingC.gameObject.layer = LayerMask.NameToLayer("Player1");
        }
        else if (p == 1)
        {
            i = x - 1;
            j = x - 1;
            CoorTemp = Coords[i][j];
            new_p = Coords[i][j].location;
            StartingC.gameObject.layer = LayerMask.NameToLayer("Player2");
        }
        else if (p == 2)
        {
            i = x - 1;
            CoorTemp = Coords[i][j];
            new_p = Coords[i][j].location;
            StartingC.gameObject.layer = LayerMask.NameToLayer("Player3");
        }
        else if (p == 3)
        {
            j = x - 1;
            CoorTemp = Coords[i][j];
            new_p = Coords[i][j].location;
            StartingC.gameObject.layer = LayerMask.NameToLayer("Player4");
        }
        StartingC.gameObject.GetComponent<Type>().Location = Coords[i][j].location;
        StartingC.gameObject.GetComponent<Type>().LocationCoords = Coords[i][j];

        Vector3 vx = new Vector3(new_p.transform.position.x, 6.7F, new_p.transform.position.z);

        GameObject temp = (GameObject)Instantiate(StartingC, vx, new_p.transform.rotation);
        //This is the list of players
        temp.transform.parent = PLAYERLIST.transform;

        Coords[i][j] = new Coordinates(temp.GetInstanceID(), 1, p, temp, Coords[i][j].location);
        PlayableC NewP = new PlayableC(0, new List<GameObject>(), new List<Spell>(), temp);
        Players.Add(NewP);

    }
    public void UndoPlayer(int p)
    {

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if (Coords[i][j].G == Players[p].Character)
                {
                    Destroy(Players[p].Character);
                    Players.RemoveAt(p);
                    Coords[i][j] = new Coordinates(-1, 0, -1, null, locations[i][j]);
                }
            }
        }
    }
    //SPELLS
    public void SetSpell(int player, string P, Sprite SP)
    {

        foreach (SpellList.Tag T in EventSystem.GetComponent<SpellList>().ALLSPELLS)
        {
            foreach (SpellList.Spell S in T.spell)
            {
                if (S.Name == P)
                {
                    Spell dx = new Spell(S.Type, P, SP);
                    Players[player].Spells.Add(dx);
                    int totalST = Players[player].SpellTotal + 1;
                    Players[player] = new PlayableC(totalST, Players[player].Minions, Players[player].Spells, Players[player].Character);
                    return;
                }
            }
        }

    }

    //BUTTONS
    public void ResetButtons()
    {
        foreach (SpellButtons SPO in SpellButtons_)
        {
            foreach (Button B in SPO.Buttons)
            {
                B.interactable = true;
            }
        }
    }

    //SPELL Related code
    public List<GameObject> AOE(RangeType RT, SpellList.Spell CurrentSpell)
    {
        Spaces.Clear();
        int r = CurrentSpell.Range;
        if (CurrentSpell.SpellRangeType == SpellRangeType.AOE || CurrentSpell.SpellRangeType == SpellRangeType.TARGETED)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (Coords[i][j].location == CurrentObject.GetComponent<Type>().Location)
                    {
                        int n_row = i - r;
                        int n_col = j - r;

                        int o_range = 3 + (2 * (r - 1));
                       // https://www.youtube.com/watch?v=Ijk4j-r7qPA
                        /*
                         * 
                         * Gets all the locations except for the actual players or spaces
                         * 
                         * 
                         * Everything you can do will affect everyone around you
                         * 
                         * group heal, heals everyone around you 
                         * aoe attack, attacks everyone 
                         * 
                         * exceptions:
                         *  >Spells that sacrifice your own minions
                         *  
                         * 
                         * Example:
                         * 
                         * if attacking, you don't want all the blocks, you want the spaces where there are enemies FRI
                         * if moving, you don't want a sapce with any enemy or foes on it FLO
                         * if healing you want all your allies spots FRI
                         * if summoning you want an empty space within the range FLO
                         * if self there is no need for choosing a position 
                         *  #When checking around we need to take into consideration the row and column of origin and range. 
                            #Range = 1 => 3 * 3 square around the original player
                            #Range = 2 => 5 * 5 ...
                            #Range = 3 => 7 * 7 ...
                            #		   3 x 3  			 5 x 5					 7x7
                            #		[X][X][X]		[X][X][X][X][X]		[X][X][X][X][X][X][X]
                            #		[X][O][X]		[X][X][X][X][X]		[X][X][X][X][X][X][X]
                            #		[X][X][X]		[X][X][O][X][X]		[X][X][X][X][X][X][X]
                            #						[X][X][X][X][X]		[X][X][X][O][X][X][X]
                            #						[X][X][X][X][X]		[X][X][X][X][X][X][X]
                            #											[X][X][X][X][X][X][X]
                            #											[X][X][X][X][X][X][X]
                            #
                         */

                        //Range == SRT

                        for (int k = 0; k < o_range; k++)
                        {
                            for (int l = 0; l < o_range; l++)
                            {
                                if ((n_row >= 0 && n_row < x) && (n_col >= 0 && n_col < x))
                                {
                                    if (RT == RangeType.FLO)
                                    {
                                        if (-1 == Coords[n_row][n_col].ID)
                                        {
                                            Spaces.Add(Coords[n_row][n_col].location);
                                        }
                                    }
                                    else if (RT == RangeType.FOE)
                                    {
                                        if (CurrentObject.layer != Coords[n_row][n_col].Team)
                                        {
                                            Spaces.Add(Coords[n_row][n_col].location);
                                        }
                                    }
                                    else if (RT == RangeType.FRI)
                                    {
                                        if (CurrentObject.layer == Coords[n_row][n_col].Team)
                                        {
                                            Spaces.Add(Coords[n_row][n_col].location);
                                        }
                                    }else if (RT == RangeType.ALL)
                                    {
                                        if(Coords[n_row][n_col].ID != -1)
                                        {
                                            Spaces.Add(Coords[n_row][n_col].location);
                                        }
                                    }
                                }
                                n_col++;
                            }
                            n_row++;
                            n_col = j - r;
                        }
                    }
                }
            }
        }
        else if (CurrentSpell.SpellRangeType == SpellRangeType.PASSIVE)
        {
            Spaces.Add(CurrentObject.GetComponent<Type>().Location);
        }else if(CurrentSpell.SpellRangeType == SpellRangeType.CONE)
        {
            Debug.Log("You're a CONE");
        }
        return Spaces;
    }
    public void UnshowShow()
    {
        foreach(GameObject SS in Spaces)
        {
            ParticleSystem pr = SS.GetComponent<ParticleSystem>();
            var main = pr.main;
            SS.GetComponent<SphereCollider>().enabled = !SS.GetComponent<SphereCollider>().enabled;
            SS.GetComponent<MeshRenderer>().enabled = !SS.GetComponent<MeshRenderer>().enabled;

            if(!SS.GetComponent<SphereCollider>().enabled && !SS.GetComponent<MeshRenderer>().enabled)
            {
                SPELLCASTING = false;
                pr.Stop();
            }
            else
            {
                SPELLCASTING = true;
                pr.Play();
            }
        }
        if (!SPELLCASTING)
        {
            _CurrentSpell = new SpellList.Spell();
            Debug.Log(_CurrentSpell.Name);
        }
    }
    public void ChosenPosition(GameObject Position)
    {
        //if a valid position
        UnshowShow();
    }

    public Color ChangeSquareColor(Color col)
    {
        if(_CurrentSpell.Name != null)
        {
            if(_CurrentSpell.Name == "Move")
            {
                col = Color.green;
            }else if(_CurrentSpell.Name == "Attack")
            {
                col = Color.red;
            }
            else
            {
                if(_CurrentSpell.Type == RangeType.FLO)
                {
                    col = Color.blue;
                }else if(_CurrentSpell.Type == RangeType.ALL)
                {
                    col = Color.yellow;
                }
            }
        }
        return col;
    }
}
        
