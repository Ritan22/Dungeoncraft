using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int hp;
    public int dmg;
    public int stack;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        dmg = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TurnController.turn){
            Danno();
        }
    }

    void Danno(){
        if (stack == 3){
            GameController.selfHp -=(dmg*2);
            //Debug.Log("Hp:"+GameController.selfHp);
            stack = 0;
            TurnController.turn = true;

        }else{
            GameController.selfHp -= dmg;
            stack += 1;
            TurnController.turn = true;
            Debug.Log("EnemyStack" + stack);
            Debug.Log("Hp:" + GameController.selfHp);
            
        }
    }
}
