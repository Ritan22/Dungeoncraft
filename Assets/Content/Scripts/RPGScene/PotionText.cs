using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionText : MonoBehaviour
{
    public Text lvPotion;
    void Update()
    {
        lvPotion.text = "" + GameController.nPotion;
    }
}