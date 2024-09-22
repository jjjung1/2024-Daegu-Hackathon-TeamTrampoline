using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DalssuTalk : MonoBehaviour
{
    public string message;
    public int type;

    public Image image;
    public GameObject Dalssu;

    public List<(string, int)> talkData;
    public int num;

    public GameObject answer;
    public GameObject talking;

    public UserDatas UDs;
    public Sprite quest;
    public Sprite wow;
    public Sprite shinning;
    public Sprite cry;
    public Sprite hmm;
    void Awake()
    {
        image = Dalssu.GetComponent<Image>();
        image.sprite = quest;
        talkData = new List<(string, int)>();
        num = 0;
        message = "어떤 일이신가요? ";
        type = 0;
        // 0는 ? 도달수 -> 저장/나가기
        // 1는 꺄 도달수 -> 업서짐
        // 2은 반짝반짝 도달수
        // 3는 울먹울먹 도달수 -> 네 / 아니오
        // 4는 흠흠 도달쑤 -> 바로 나가짐
    }

    public void Next()
    {
        if (answer.activeSelf == true)
        {
            talking.SetActive(false);
        }
        if (num < talkData.Count)
        {
            (message, type) = talkData[num];
            num++;
        }
        else
        {
            UDs.newone = false;
            gameObject.SetActive(false); // 원하는 씬 이름으로 수정하세요.
        }

    }

    public void Update()
    {
        switch (type)
        {
            case 0:
                image.sprite = quest;
                break;
            case 1:
                image.sprite = wow;
                break;
            case 2:
                image.sprite = shinning;
                break;
            case 3:
                image.sprite = cry;
                break;
            case 4:
                image.sprite = hmm;
                break;

        }
    }
}
