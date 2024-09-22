using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class talking : MonoBehaviour
{
    public DalssuTalk DT;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        text.text = DT.message;
    }
}
    

