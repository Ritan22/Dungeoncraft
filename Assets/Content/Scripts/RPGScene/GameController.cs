using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Animator enemyAnimator;
    public static int recordDungeon;
    public static int nPotion;
    public static int playerMoney;
    public static int dungeonLevel;
    public static int playerHp;
    public static int stack;
    [Header("Armi")]

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
    [SerializeField] private GameObject battleInterface;
    [SerializeField] private GameObject deathInterface;
    [SerializeField] private GameObject nextLevelCanvas;
    [SerializeField] private GameObject background;
    
    public GameObject[] enemies;
    //--------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        playerHp = 1000;
        stack = 0;
        dungeonLevel = 1;

        //consumo armi
        stackAxe = 3;
        stackBow = 3;
        stackKnife = 3;

        //danni armi
        // dmgSword = 8;
        dmgAxe = 8;
        dmgKnife = 8;
        dmgBow = 8;

        Instantiate(enemies[Random.Range(0, enemies.Length)]);
    }
    //--------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        if (playerHp <= 0)
        {
            Death();
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------------

    private void Death(){
        battleInterface.SetActive(false);
        deathInterface.SetActive(true);
        nPotion = 0;
        if (recordDungeon < dungeonLevel){
            recordDungeon = dungeonLevel;
        }
        print(recordDungeon);
    }
    public void Axe(){
        if (stack >= stackAxe)
        {
            stack -= stackAxe;
            Enemy.enemyHp -= dmgAxe;
            TurnController.turn = false;
        }
        
    }
    public void Bow(){
        if (stack >= stackBow)
        {
            stack -= stackBow;
            Enemy.enemyHp -= dmgBow;
            TurnController.turn = false;
        }
    }
    public void Knife(){
        if (stack >= stackKnife)
        {
            stack -= stackKnife;
            Enemy.enemyHp -= dmgKnife;
            TurnController.turn = false;
        }
    }

    public void DamageEnemy(){
        
        if (Enemy.enemyHp <= 0) {
            nextLevelCanvas.SetActive(true);
            background.SetActive(false);
        }
        stack +=1;
        stack = Mathf.Clamp(stack, 0,6);
    }

    public void NextLevel() {
        dungeonLevel++;
        nextLevelCanvas.SetActive(false);
        background.SetActive(true);
        stack = 0;
        Instantiate(enemies[Random.Range(0, enemies.Length)]);
    }
}
