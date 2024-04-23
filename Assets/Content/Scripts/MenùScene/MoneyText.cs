using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public Text money;
    void Update()
    {
        money.text = "" + GameController.playerMoney;
    }
}
