using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int hp;
    private int maxHp;
    public int dmg;
    public int stack;

    public SpriteRenderer enemyState;
    public Sprite state2;
    public Sprite state3;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        maxHp = hp;
        dmg = 5;
        enemyState = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!TurnController.turn){
            Danno();
        }
        if (hp <= (maxHp / 3))
        {
            ChangeState(3);
        }else if (hp <= (maxHp / 3) * 2)
        {
            ChangeState(2);
        }
        print((maxHp / 3) * 2);
        print((maxHp / 3));
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
            
            
        }
    }

    void ChangeState(int state)
    {
        if(state == 2)
        {
            enemyState.sprite = state2;
        }
        if (state == 3)
        {
            enemyState.sprite = state3;
        }
    }

}
