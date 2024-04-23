using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private int stackBow;
    private int dmg;
    public static int bowLevel;
    public static int cost;
    // Start is called before the first frame update
    void Start()
    {
        stackBow = 3 - (bowLevel % 3);
        dmg = 8 + (bowLevel / 3 * 4);
    }

    public void DamageBow(){
        if (GameController.stack >= stackBow)
        {
            GameController.stack -= stackBow;
            if (Enemy.weakness1 == "axe" || Enemy.weakness2 == "axe"){
                
            }else{
                TurnController.turn = false;
            }
            Enemy.enemyHp -= dmg;
            
        }
    }
    
}
