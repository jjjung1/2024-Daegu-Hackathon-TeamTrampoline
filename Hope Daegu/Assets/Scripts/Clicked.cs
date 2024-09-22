using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Clicked : MonoBehaviour
{
    public GameObject answer;
    public UserDatas UDs;
    public DalssuTalk DT;
    public talking talk;
    public TextMeshProUGUI text;
    public void OnClicked()
    {
        if(text.text == "저장")
        {
            answer.SetActive(false);
            DT.talkData.Add(("좋아요! 지금까지의(닉네임)님의 멋진 일상을 하나하나 기록해둘게요!", 2));
            DT.talkData.Add(("완료했습니다! 앞으로도 파이팅이에요!", 1));
            DT.Next();
            PlayerPrefs.SetString("nickname", UDs.nickname);
            PlayerPrefs.SetInt("power_max", UDs.power_max);
            PlayerPrefs.SetInt("power_percent", UDs.power_percent);
            PlayerPrefs.SetInt("money", UDs.money);
            string json = JsonUtility.ToJson(new Serialization<string>(UDs.inventory));
            PlayerPrefs.SetString("inventory", json);
            PlayerPrefs.Save();


        }
        else if(text.text == "나가기")
        {
           
        }else if(text.text == "가야 돼")
        {

        }else if(text.text == "알았어.. 안갈게")
        {
            talk.gameObject.SetActive(false);
        }
    }
}
