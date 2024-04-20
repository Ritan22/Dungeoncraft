using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private int stackSword;
    private int dmgSword;
    public static int swordLevel;
    // Start is called before the first frame update
    void Start()
    {
        stackSword = 3 - (swordLevel % 3);
        dmgSword = 8 + (swordLevel / 3 * 4);
    }

    public void DamageSword(){
        if (GameController.stack >= stackSword)
        {
            GameController.stack -= stackSword;
            Enemy.hp -= dmgSword;
            TurnController.turn = false;
        }
    }
}
