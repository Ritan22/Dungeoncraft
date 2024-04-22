using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvText : MonoBehaviour
{
    public Text lvText;
    void Update()
    {
        lvText.text = "Lv: " + GameController.dungeonLevel;
    }
}
