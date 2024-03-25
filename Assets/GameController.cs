using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int livelloDungeon;
    public static int selfHp;
    [Range(0,6)]public static int stack;
    [Header("Armi")]
    public int consumoSword;
    public int consumoAxe;
    public int consumoBow;
    public int consumoKnife;

    // Start is called before the first frame update
    void Start()
    {
        selfHp = 100;
        stack = 0;

        //consumo armi
        
        consumoSword = 3;
        consumoAxe = 3;
        consumoBow = 3;
        consumoKnife = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addStack(){
        stack +=1;
        stack = Mathf.Clamp(stack, 0,6);
        Debug.Log(stack);
    }

    public void Sword(){
        stack -= consumoSword;
    }
    public void Axe(){
        stack -= consumoAxe;
    }
    public void Bow(){
        stack -= consumoBow;
    }
    public void Knife(){
        stack -= consumoKnife;
    }
}
