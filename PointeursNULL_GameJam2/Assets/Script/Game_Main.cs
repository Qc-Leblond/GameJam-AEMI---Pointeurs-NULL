using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Main : MonoBehaviour 
{
    private int RoundCount = 0;
    private bool NewRound = false;

    public GameObject Zombie;
    public GameObject Human;

    private List<GameObject> HumanList = new List<GameObject>();
    private List<GameObject> ZombieList = new List<GameObject>();

    void Awake()
    {
        AddToRoundCount();
    }

    void Update()
    {
        if (NewRound)
        {
            NewRound = false;
            GetComponent<Timer>().NewTimer();
        }
    }

    public void SpawnZombie()
    {
        GameObject ZombieObject = Instantiate(Zombie, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        ZombieList.Add(ZombieObject);
    }

    public void SpawnHuman()
    {
        GameObject HumanObject = Instantiate(Human, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        HumanList.Add(HumanObject);
    }

    public void AddToRoundCount() { RoundCount++; NewRound = true; }

}
