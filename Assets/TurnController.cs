using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public static bool turn;
    public GameObject comands;
    // Start is called before the first frame update
    void Start()
    {
        turn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (turn == true){
            comands.SetActive(true);
        }
        if (turn == false){
            comands.SetActive(false);
            Damage();
            
        }
    }

    void Damage(){
        Enemy.hp -= 10;
        Debug.Log(Enemy.hp);
    }

    public void AntiTurn(){
        turn = false;
    }
}
