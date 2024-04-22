using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private int stackBow;
    private int dmgBow;
    public static int bowLevel;
    // Start is called before the first frame update
    void Start()
    {
        stackBow = 3 - (bowLevel % 3);
        dmgBow = 8 + (bowLevel / 3 * 4);
    }

    public void DamageBow(){
        if (GameController.stack >= stackBow)
        {
            GameController.stack -= stackBow;
            Enemy.enemyHp -= dmgBow;
            TurnController.turn = false;
        }
    }
}
