using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private UserData UD;
    public TextMeshProUGUI nameText;
    [SerializeField] private Image image;
    // Start is called before the first frame update
    void Start()
    {
        Transform nameTransform = transform.Find("name");
        nameText = nameTransform.GetComponent<TextMeshProUGUI>();
        image.color = new UnityEngine.Color(215 / 255f, 163 / 255f, 81 / 255f);
    }
    // Update is called once per frame
    void Update()
    {
       if(nameText.text == "´Þ¾¥" || nameText.text == "???")
        {
            image.color = new UnityEngine.Color(215 / 255f, 163 / 255f, 81 / 255f);
        }
       else if(nameText.text == UD.nickname)
        {
            image.color = new UnityEngine.Color(122 / 255f, 192 / 255f, 114 / 255f);
        }
    }
}
