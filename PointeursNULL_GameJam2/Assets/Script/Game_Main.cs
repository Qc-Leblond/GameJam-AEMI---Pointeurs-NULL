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
    public GameObject camera;

    private List<GameObject> HumanList = new List<GameObject>();
    private List<GameObject> ZombieList = new List<GameObject>();
    private List<GameObject> objectiveList = new List<GameObject>();

    private List<Vector3> ObjectiveLocation = new List<Vector3>();

    private int LimitZombie = 5;
    private int LimitHuman = 3;

    private int activeZombie = 0;
    private int activeHuman = 0;


    void Awake()
    {
        AddToRoundCount();
        PotentialObjectiveCoordinates();
        SpawnHuman();
        SpawnZombie();
        SpawnObjective();

    }

    void Update()
    {
        
		if (RoundCount % 2 == 1)
		{
            for (int i=0; i<=(HumanList.Count -1); i++)
			HumanList[i].GetComponent<Character_Controller>().DontMove();
		//	ZombieList[0].GetComponent<Character_Controller>().Move();
            if (Input.GetButtonDown("Spawn"))
            {
                SpawnZombie();
            }
            if(Input.GetButtonDown("Change"))
            {
                ChangeControlZombie();
            }
		}
		else if (RoundCount % 2 == 0)
        {
            for (int i = 0; i <= (ZombieList.Count) - 1; i++)
                ZombieList[i].GetComponent<Character_Controller>().DontMove();
		//	HumanList[0].GetComponent<Character_Controller>().Move();
            if(Input.GetButtonDown("P2Spawn"))
            {
                Debug.Log("spawn button");
                SpawnHuman();
            }
            if (Input.GetButtonDown("P2Change"))
            {
                Debug.Log("change button");

                ChangeControlHuman();
            }
            
		}

        if (NewRound)
        {
            if (RoundCount%2 == 0)
            {
                activeHuman = 0;
                ChangeControlHuman();
                for (int i = 0;i<ZombieList.Count;i++)
                {
                    ZombieList[i].GetComponent<Animator>().SetBool("Jump", false);
                    ZombieList[i].GetComponent<Animator>().SetFloat("Speed", 0.0f);

                }
            }
            else if (RoundCount % 2 == 1)
            {
                activeZombie = 0;
                ChangeControlZombie();
                for (int i = 0; i < HumanList.Count; i++)
                {
                    HumanList[i].GetComponent<Animator>().SetBool("Jump", false);
                    HumanList[i].GetComponent<Animator>().SetFloat("Speed", 0.0f);

                }
            }

            
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
            Debug.Log(ZombieList);
                ChangeControlZombie();
        }
        else Debug.Log("Zombie Limit!");
    }

    public void SpawnHuman()
    {
        if (LimitHuman >= HumanList.Count)
        {
            GameObject HumanObject = Instantiate(Human, new Vector3(60f, 4.3f, 0), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            HumanObject.transform.localScale = new Vector3(-5, 5, 1);
            HumanObject.GetComponent<Character_Controller>().isHuman = true;
            HumanList.Add(HumanObject);
            ChangeControlHuman();
        }
        else Debug.Log("Human Limit!");
    }

    public void AddToRoundCount() { RoundCount++; NewRound = true; }

    public int GetRoundCount() { return RoundCount; }

    private void SpawnObjective()
    {
        Debug.Log(ObjectiveLocation.Count);
        for (int i = 0; i < (ObjectiveLocation.Count); i++)
        {
            //Vector3 rand = ObjectiveLocation[Random.Range(0, ObjectiveLocation.Count)];
            GameObject ObjectiveObject = Instantiate(Objective,ObjectiveLocation[i], Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
            objectiveList.Add(ObjectiveObject);
           // ObjectiveLocation.Remove(rand);
        }
    }

    private void PotentialObjectiveCoordinates()
    {
        ObjectiveLocation.Add(new Vector3(0, 1, 0));
        ObjectiveLocation.Add(new Vector3(0, 27.5f, 0));
        ObjectiveLocation.Add(new Vector3(-16, 21, 0));
        ObjectiveLocation.Add(new Vector3(16, 21, 0));
        ObjectiveLocation.Add(new Vector3(16, 51, 0));
        ObjectiveLocation.Add(new Vector3(-16, 51, 0));
        ObjectiveLocation.Add(new Vector3(0, 36, 0));
        ObjectiveLocation.Add(new Vector3(48, 51, 0));
        ObjectiveLocation.Add(new Vector3(-48, 51, 0));
        ObjectiveLocation.Add(new Vector3(-32, 36, 0));
        ObjectiveLocation.Add(new Vector3(32, 36, 0));


    }


    private void ChangeControlZombie()
    {
        Debug.Log(activeZombie.ToString());
        if (activeZombie != 0)
            ZombieList[activeZombie - 1].GetComponent<Character_Controller>().canMove = false;
        if (activeZombie >= (ZombieList.Count))
            activeZombie = 0;
        ZombieList[activeZombie].GetComponent<Character_Controller>().canMove = true;


        camera.transform.parent = ZombieList[activeZombie].transform;
        camera.transform.position = (ZombieList[activeZombie].transform.position + new Vector3(0, 0.5f, -10));
        activeZombie++;
    }

    private void ChangeControlHuman()
    {
        Debug.Log(activeHuman.ToString());
        if (activeHuman != 0)
            HumanList[activeHuman - 1].GetComponent<Character_Controller>().canMove = false;
        if (activeHuman >= (HumanList.Count))
            activeHuman = 0;
        HumanList[activeHuman].GetComponent<Character_Controller>().canMove = true;


        camera.transform.parent = HumanList[activeHuman].transform;
        camera.transform.position = (HumanList[activeHuman].transform.position + new Vector3(0, 0.5f, -10));
        activeHuman++;
    }

    public void ZombieDeath(GameObject Zombie)
    {
        ZombieList.Remove(Zombie);
        Destroy(Zombie);
    }

    public void HumanDeath(GameObject Human)
    {
        HumanList.Remove(Human);
        Destroy(Human);
    }

    public void HumanTransform(GameObject Human)
    {
        HumanList.Remove(Human);
        Vector3 Pos = Human.transform.position;
        Destroy(Human);
        GameObject NewZombie = Instantiate(Zombie, Pos, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        ZombieList.Add(NewZombie);
    }
}
