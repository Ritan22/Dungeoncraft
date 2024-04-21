using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackText : MonoBehaviour
{
    public Text stackText;
    void Update()
    {
        stackText.text = GameController.stack+"/6";
    }
}
