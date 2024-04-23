using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private int stackKnife;
    private int dmg;
    public static int knifeLevel;
    public static int cost;
    // Start is called before the first frame update
    void Start()
    {
        stackKnife = 3 - (knifeLevel % 3);
        dmg = 8 + (knifeLevel / 3 * 4);
    }

    public void DamageKnife(){
        if (GameController.stack >= stackKnife)
        {
            GameController.stack -= stackKnife;
            if (Enemy.weakness1 == "axe" || Enemy.weakness2 == "axe"){
                
            }else{
                TurnController.turn = false;
            }
            Enemy.enemyHp -= dmg;
            
        }
    }
}
