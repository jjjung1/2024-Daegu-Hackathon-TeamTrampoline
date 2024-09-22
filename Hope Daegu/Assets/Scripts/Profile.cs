using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myname;
    [SerializeField] private TextMeshProUGUI power;
    [SerializeField] private TextMeshProUGUI money;

    [SerializeField] private UserDatas UDs;

    private void Awake()
    {
        myname.text = UDs.nickname;
        power.text = string.Format("{0} / {1} ({2}%)", UDs.power_max * UDs.power_percent / 100, UDs.power_max, UDs.power_percent);
        money.text = string.Format("{0} \\", UDs.money);
    }
}
