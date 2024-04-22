using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private int stackBow;
    private int dmgAxe;
    public static int axeLevel;
    // Start is called before the first frame update
    void Start()
    {
        stackBow = 3 - (axeLevel % 3);
        dmgAxe = 8 + (axeLevel / 3 * 4);
    }

    public void DamageAxe(){
        if (GameController.stack >= stackBow)
        {
            GameController.stack -= stackBow;
            Enemy.enemyHp -= dmgAxe;
            TurnController.turn = false;
        }
    }
}
