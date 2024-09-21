using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public Senario senario;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void ButtonClick()
    {
        senario.Next();
        gameObject.SetActive(false);
    }
}
