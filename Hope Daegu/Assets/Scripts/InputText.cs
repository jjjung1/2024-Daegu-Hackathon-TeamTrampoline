using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    [SerializeField] private UserData UD;
    [SerializeField] private GameObject Text;
    public Senario senario;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ButtonClick()
    {
        string n = Text.GetComponent<TextMeshProUGUI>().text;
        if (n != "") // ó�� �ȵ� �̤�
        {;
            UD.nickname = n;
            senario.Next();
            gameObject.SetActive(false);
        }
  
    }
}
