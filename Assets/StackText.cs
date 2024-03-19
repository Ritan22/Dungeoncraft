using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackText : MonoBehaviour
{
    public Text stackText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stackText.text = "Stack: "+ GameController.stack;
    }
}
