using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    [SerializeField] private UserDatas UDs;
    // Start is called before the first frame update
    void Awake()
    {
        if (UDs.newone == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    
}
