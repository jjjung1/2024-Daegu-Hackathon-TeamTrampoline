using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public string nickname;

    private static UserData instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static UserData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UserData>();
            }
            return instance;
        }
    }
}




