using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Name : MonoBehaviour
{
    public UserData UD;
    public Senario senario;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "??";
    }

    // Update is called once per frame
    void Update()
    {
        if (senario.num <= 2) text.text = "???";
        else if (senario.talker == 1) text.text = "´Þ¾¥";
        else if (senario.talker == 0) text.text = UD.nickname;
    }
}
