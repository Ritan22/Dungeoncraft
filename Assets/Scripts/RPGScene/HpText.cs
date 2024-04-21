using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpText : MonoBehaviour
{
    public Text Hp;
    void Update()
    {
        Hp.text = "" + GameController.selfHp;
    }
}
