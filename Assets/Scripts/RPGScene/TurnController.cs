using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public static bool turn;
    public GameObject comands;
    public static int NTurn;
    // Start is called before the first frame update
    void Start()
    {
        turn = true;
        NTurn = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (turn == true){
            comands.SetActive(true);
        }
        if (turn == false){
            comands.SetActive(false);
            GameController.Damage();
        }

        if (Enemy.hp <= 0)
        {
            NTurn += 1;
            print(NTurn);
        }
    }

    public void AntiTurn(){
        turn = false;
    }
}
