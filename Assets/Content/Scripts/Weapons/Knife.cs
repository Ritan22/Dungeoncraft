using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private int stackKnife;
    private int dmgKnife;
    public static int knifeLevel;
    // Start is called before the first frame update
    void Start()
    {
        stackKnife = 3 - (knifeLevel % 3);
        dmgKnife = 8 + (knifeLevel / 3 * 4);
    }

    public void DamageKnife(){
        if (GameController.stack >= stackKnife)
        {
            GameController.stack -= stackKnife;
            Enemy.enemyHp -= dmgKnife;
            TurnController.turn = false;
        }
    }
}
