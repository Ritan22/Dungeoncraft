using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPotion : MonoBehaviour
{
    public void AddHP(){
        if (GameController.nPotion > 0){
            GameController.nPotion--;
            GameController.playerHp += 50;
        }
    }
}
