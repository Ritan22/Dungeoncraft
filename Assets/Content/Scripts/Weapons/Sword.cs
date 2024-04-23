using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private int stackSword;
    private int dmg;
    public static int swordLevel;
    public static int cost;
    // Start is called before the first frame update
    void Start()
    {
        stackSword = 3 - (swordLevel % 3);
        dmg = 8 + (swordLevel / 3 * 4);
    }

    public void DamageSword(){
        if (GameController.stack >= stackSword)
        {
            GameController.stack -= stackSword;
            if (Enemy.weakness1 == "axe" || Enemy.weakness2 == "axe"){
                
            }else{
                TurnController.turn = false;
            }
            Enemy.enemyHp -= dmg;
            
        }
    }
}
