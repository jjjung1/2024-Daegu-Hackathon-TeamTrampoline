using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallonText : MonoBehaviour
{
    public Senario senario;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = senario.message;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = senario.message;
        if(senario.type == 2)
        {
            text.fontSize = 25;
        }
        else
        {
            text.fontSize = 37;
        }
    }
}
