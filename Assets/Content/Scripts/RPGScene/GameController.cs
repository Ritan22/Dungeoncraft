using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int playerDamage;
    public static int recordDungeon; // è il massimo livello che ho raggiunto nel dungeon
    public static int nPotion; // è il numero di pozioni che il giocatore ha a disposizione nella partita corrente 
    public static int playerMoney; // sono i soldi che il giocatore posside
    public static int dungeonLevel; // è il livello del Dungeon che aumenta ogni volta che sconfiggi un nemico
    public static int playerHp; // sono gli hp del giocatore
    public static int stack; // sono le stack del giocatore

    [Header("Canvas")]
    [SerializeField] private GameObject battleInterface;
    [SerializeField] private GameObject deathInterface;
    [SerializeField] private GameObject nextLevelCanvas;
    [SerializeField] private GameObject background;

    private bool enemyDeath;
    
    public GameObject[] enemies;
    //--------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        playerDamage = -10;
        playerHp = 1000; 
        stack = 0; // La partita inizia con 0 stack per le armi
        dungeonLevel = 1; // Il dungeon inizia dal livello 1

        Instantiate(enemies[Random.Range(0, enemies.Length)]); // se si volessero aggiungere più nemici
    }

    void Update()
    {
        // quando il player raggiunge 0 hp parte la funzione Death() 
        if (playerHp <= 0)
        {
            Death();
        }
        if (GameObject.FindGameObjectWithTag("Enemy") != null){
        if (Enemy.enemyHp <= 0) {
            if (background.activeSelf){
                nextLevelCanvas.SetActive(true);
                background.SetActive(false);
                TurnController.turn = true;
            }if (enemyDeath){
                nextLevelCanvas.SetActive(false); // disattiva la Canva per passare di livello
                background.SetActive(true);// riattiva la Canva per la scelta delle azioni in partita
                enemyDeath = false;
            }
        }
        }
        
    }
    //--------------------------------------------------------------------------------------------------------------------------------

    // funzione che si avvia nel momento in qui il giocaotore finisce gli hp
    private void Death(){
        battleInterface.SetActive(false); // disattiva la Canva di battleInterface
        deathInterface.SetActive(true); // attiva la Canva di deathInterface
        nPotion = 0; // resetta il numero di pozioni siccome non sono un item accumolabile tra le partite

        // permettere di verificare se il record del dungeon è superiore al livello raggiunto e in caso lo memorizza
        if (recordDungeon < dungeonLevel){
            recordDungeon = dungeonLevel;
        }
    }

    public void DamageEnemy(){
        // controlla se il nemico ha perso tutti gli hp e attiva e disattiva le giuste Canva per passare al livello successivo
        
        stack +=1; // aumenta le stack dopo aver sferrato un attacco semplice
        stack = Mathf.Clamp(stack, 0,6); // impedisce al numero di stack di superare le 6 unità
        TurnController.turn = false; // setta il turno a false in modo da passare al turno avversario
    }

    public void NextLevel() {
        dungeonLevel++; // aumento di una unità il livello del dungeon
        stack = 0; // imposta le stack a 0 siccome ogni battaglia è a se
        Instantiate(enemies[Random.Range(0, enemies.Length)]); // riposiziona uno dei nemici presenti nella lista
        nextLevelCanvas.SetActive(false); // disattiva la Canva per passare di livello
        background.SetActive(true);// riattiva la Canva per la scelta delle azioni in partita
        enemyDeath = true;
        
    }
}
