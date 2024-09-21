using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public Senario senario;

    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void Update()
    {
        if (senario.talker != 0)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
}
