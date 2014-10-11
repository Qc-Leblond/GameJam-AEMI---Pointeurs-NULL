using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Main : MonoBehaviour 
{
    private int RoundCount = 0;
    private bool NewRound = false;
    private int ObjectiveLimit;

    public GameObject Zombie;
    public GameObject Human;
    public GameObject Objective;

    private List<GameObject> HumanList = new List<GameObject>();
    private List<GameObject> ZombieList = new List<GameObject>();
    private List<Vector3> ObjectiveLocation = new List<Vector3>();

    private int LimitZombie = 5;
    private int LimitHuman = 3;

    void Awake()
    {
        AddToRoundCount();
        PotentialObjectiveCoordinates();
    }

    void Update()
    {
		if (RoundCount % 2 == 1)
		{
			Human.GetComponent<Character_Controller>().DontMove();
			Zombie.GetComponent<Character_Controller>().Move();
            if (Input.GetButtonDown("Spawn"))
            {
                SpawnZombie();
            }
		}
		else if (RoundCount % 2 == 0)
		{
			Zombie.GetComponent<Character_Controller>().DontMove();
			Human.GetComponent<Character_Controller>().Move();
            if(Input.GetButtonDown("P2Spawn"))
            {
                SpawnHuman();
            }
		}

        if (NewRound)
        {
            NewRound = false;
            GetComponent<Timer>().NewTimer();
        }
    }

    public void SpawnZombie()
    {
        if (LimitZombie >= ZombieList.Count)
        {
            GameObject ZombieObject = Instantiate(Zombie, new Vector3(-60f, 4.3f, 0), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            ZombieList.Add(ZombieObject);
        }
        else Debug.Log("Zombie Limit!");
    }

    public void SpawnHuman()
    {
        if (LimitHuman >= HumanList.Count)
        {
            GameObject HumanObject = Instantiate(Human, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            HumanList.Add(HumanObject);
        }
        else Debug.Log("Human Limit!");
    }

    public void AddToRoundCount() { RoundCount++; NewRound = true; }

    public int GetRoundCount() { return RoundCount; }

    private void SpawnObjective()
    {
        for (int i = 0; i < ObjectiveLimit; i++)
        {
            Vector3 rand = ObjectiveLocation[Random.Range(0, ObjectiveLocation.Count)];
            GameObject ObjectiveObject = Instantiate(Objective, rand, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
            ObjectiveLocation.Remove(rand);
        }
    }

    private void PotentialObjectiveCoordinates()
    {
        ObjectiveLocation.Add(new Vector3(0,0,0));
    }
}
