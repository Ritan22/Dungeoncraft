using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Enemy : MonoBehaviour
{
    private Animator enemyAnimator;
    public static int getMoney;
    [SerializeField]private int money;
    public static int enemyHp;
    private int maxHp;
    private int dmg;
    private int stack;

    [Header("States")]
    public SpriteRenderer enemyState;
    public Sprite state2;
    public Sprite state3;

    [Header("Weaknesses")]
    private string[] weaknesses = {"none", "bow", "sword", "knife", "axe"};
    public string weakness1;
    public string weakness2;

    // Start is called before the first frame update
    void Start()
    {
        // ogni 5 livelli aumenta gli hp di 20
        enemyHp = 100 + (GameController.dungeonLevel/5 * 20);
        maxHp = enemyHp;
        dmg = 5;
        enemyState = GetComponent<SpriteRenderer>();
        weakness1 = weaknesses[Random.Range(1, weaknesses.Length)];
        weakness2 = weaknesses[Random.Range(0, weaknesses.Length)];
        getMoney = money;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TurnController.turn){
            StartCoroutine(DamageToPlayer());
        }
        if (enemyHp <= (maxHp / 3))
        {
            ChangeState(3);
        }else if (enemyHp <= maxHp / 3 * 2)
        {
            ChangeState(2);
        }

    }

    IEnumerator DamageToPlayer(){
        yield return new WaitForSeconds(2);
        if (stack == 3){
            // /5 *5 --> essendo dungeonLevel un intero quando divido per 5 scarta i decimali. es--> 2/5 = 0 oppure 8/5 = 1
            GameController.playerHp -= dmg*2 + (GameController.dungeonLevel/5 * 5);
            stack = 0;
            TurnController.turn = true;
        }else{
            GameController.playerHp -= dmg + (GameController.dungeonLevel/5 * 5);
            stack += 1;
            TurnController.turn = true;
        }
        StopAllCoroutines();
    }

    public void SelfDamage(){
        enemyHp -=10;
        if (enemyAnimator == null){
            enemyAnimator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        }
        enemyAnimator.SetTrigger("Damage");
        if (Enemy.enemyHp <= 0) {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            TurnController.turn = true;
            GameController.playerMoney += money;
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
