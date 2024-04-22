using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public static Animator damageAnimator;
    public Text damage;

    void Update()
    {
        damage.text = "" + GameController.playerDamage;
    }
}
