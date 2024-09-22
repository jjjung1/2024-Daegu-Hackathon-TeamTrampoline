using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public string message;
    public int type;

    public Image image;
    public GameObject Dalssu;

    public List<(string, int)> talkData;
    public int num;

    public UserDatas UDs;
    public Sprite happy;
    public Sprite cry;
    public Sprite shinning;
    public Sprite hmm;
    void Awake()
    {
        image = Dalssu.GetComponent<Image>();
        image.sprite = happy;
        talkData = new List<(string, int)>();
        num = 0;
        message = "대구에 오신 걸 환영합니다! 어때요, 멋있죠?";
        type = 0; 
        // 0는 조은 도달수
        // 1는 우는 도달수
        // 2은 반짝반짝 도달수
        // 3는 흠흠 도달수
        GenerateData();
    }
    public void GenerateData()
    {
        talkData.Add((string.Format("지금도 충분히 멋지지만 {0}님께서 더 멋진 대구를 만들어주실거라 전 믿어요", UDs.nickname), 2));
        talkData.Add(("한 가지 아쉬운 점은 며칠 전에 내린 거센 비 때문에 현재는 '사람들이 많은 곳'과‘반짝반짝한 곳'밖에 갈 수 없어요.", 1));
        talkData.Add(("나머지 곳들도 정말 멋진 곳이지만 일단 지금 갈 수 있는 곳부터 들러봐요..!", 0));
        talkData.Add(("지도에서 원하시는 곳을 고르면 갈 수 있어요! 교통비는 단돈 1500원!", 2));
        talkData.Add(("그래도 첫 이동만큼은 무리하지 마시라고 제가 미리 소매넣기를 좀 해놓았죠", 3));
        talkData.Add(("저희 대구를 위해 힘써주시는 건 좋지만 아무래도 너무 열심히 하시다보면 피로도가 바닥날 수 있으니 미리미리 음식을 먹어두는 게 좋아요", 2));
        talkData.Add(("그럼 같이 가볼까요? 용건이 생긴다면 저 달쑤에게 말을 걸어주세요! ", 0));
    }
    // Update is called once per frame
    public void Next()
    {

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
                image.sprite = happy;
                break;
            case 1:
                image.sprite = cry;
                break;
            case 2:
                image.sprite = shinning;
                break;
            case 3:
                image.sprite = hmm;
                break;

        }
    }
}
