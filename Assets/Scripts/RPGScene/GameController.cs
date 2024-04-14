using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int livelloDungeon;
    public static int selfHp;
    public int simpleAttack;
    [Range(0,6)]public static int stack;
    [Header("Armi")]
    public int stackSword;
    public int dmgSword;
    [Space(5)]
    public int stackAxe;
    public int dmgAxe;
    [Space(5)]
    public int stackBow;
    public int dmgBow;
    [Space(5)]
    public int stackKnife;
    public int dmgKnife;
    [Header("Canvas")]
    public GameObject BattleInterface;
    public GameObject DeathInterface;
    //--------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        selfHp = 100;
        stack = 0;
        simpleAttack = 5;

        //consumo armi
        stackSword = 3;
        stackAxe = 3;
        stackBow = 3;
        stackKnife = 3;

        //danni armi
        dmgSword = 8;
        dmgAxe = 8;
        dmgKnife = 8;
        dmgSword = 8;
    }
    //--------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        if (selfHp <= 0)
        {
            BattleInterface.SetActive(false);
            DeathInterface.SetActive(true);
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------------
    public void addStack(){
        stack +=1;
        stack = Mathf.Clamp(stack, 0,6);
        //Debug.Log(stack);
    }

    public void Sword(){
        if (stack >= stackSword)
        {
            stack -= stackSword;
            Enemy.hp -= dmgSword;
        }
    }
    public void Axe(){
        if (stack >= stackAxe)
        {
            stack -= stackAxe;
            Enemy.hp -= dmgAxe;
        }
        
    }
    public void Bow(){
        if (stack >= stackBow)
        {
            stack -= stackBow;
            Enemy.hp -= dmgBow;
        }
    }
    public void Knife(){
        if (stack >= stackKnife)
        {
            stack -= stackKnife;
            Enemy.hp -= dmgKnife;
        }
    }

    public static void Damage(){
        Enemy.hp -= 10;
        Debug.Log(Enemy.hp);
    }
}
