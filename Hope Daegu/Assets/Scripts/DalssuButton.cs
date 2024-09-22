using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalssuButton : MonoBehaviour
{

    public Clicked c;
    public DalssuTalk DT;
    public UserDatas UDs;
    public talking talk;
    public void Awake()
    {
        DT.num = 0;

    }
    public void OnClick()
    {
        if(UDs.newone == false)
            talk.gameObject.SetActive(true);

        c.Awake();
        DT.Awake();
    }
}
