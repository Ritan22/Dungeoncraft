using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private int stackAxe;
    private int dmg;
    public static int axeLevel;

    public static int cost;
    // Start is called before the first frame update
    void Start()
    {
        stackAxe = 3 - (axeLevel % 3);
        dmg = 8 + (axeLevel / 3 * 4);
    }

    public void DamageAxe(){
        if (GameController.stack >= stackAxe)
        {
            GameController.stack -= stackAxe;
            if (Enemy.weakness1 == "axe" || Enemy.weakness2 == "axe"){
                
            }else{
                TurnController.turn = false;
            }
            Enemy.enemyHp -= dmg;
            
        }
    }


}
