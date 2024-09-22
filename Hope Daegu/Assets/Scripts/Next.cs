using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public Senario senario;

    public void ButtonClick()
    {
        if (senario.type != 7 && senario.type != 5 && senario.type != 10)
        {
            senario.Next();
        }
    }
}
