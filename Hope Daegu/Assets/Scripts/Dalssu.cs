using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dalssu : MonoBehaviour
{
    public Senario senario;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }
    public void Update()
    {
        if(senario.talker != 1)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }

}
