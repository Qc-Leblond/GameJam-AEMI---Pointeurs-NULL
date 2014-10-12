using UnityEngine;
using System.Collections;

public class Human_Handling : MonoBehaviour
{
    private bool Incapacitated = false;
    private int TurnToZombie;
    public GameObject Main;

    void Start()
    {
        TurnToZombie = 2;
    }

    void Update()
    {
        if (TurnToZombie == 0)
        {
            Main.GetComponent<Game_Main>().ZombieDeath(gameObject);
        }
    }

    public void GetBitten() { Incapacitated = true; }
    public bool isIncapacitated() { return Incapacitated; }
    public void RemoveTurnToZombie() { TurnToZombie -= 1; }
}
