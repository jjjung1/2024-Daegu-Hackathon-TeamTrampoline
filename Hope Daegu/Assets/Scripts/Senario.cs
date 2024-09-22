using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Senario : MonoBehaviour
{
    public int talker;
    public string message;
    public int type;

    public List<(int, string, int)> talkData;
    public int num;

    public GameObject Dalssu;
    public GameObject User;
    public GameObject inputbox;
    public GameObject answer;

    public UserData UD;
    public Image image;

    public Sprite shadow;
    public Sprite dumb;
    public Sprite happy;
    public Sprite cry;
    public Sprite shinning;
    public Sprite quest;
    public Sprite wow;
    public Sprite hmm;

    public void Awake()
    {

        image = Dalssu.GetComponent<Image>();
        image.sprite = shadow;
        talkData = new List<(int, string, int)>();
        num = 0;
        talker = 1;
        message = ".......";
        type = 0; //1은 질문, 2는 작은 글씨
        // 0은 그림자 도달수
        // 3은 멍청 도달수
        // 4는 조은 도달수
        // 2, 5는 우는 도달수
        // 6, 10은 반짝반짝 도달수
        // 7은 ? 도달수
        // 8은 꺄 도달수
        // 9는 흠흠 도달수
        // 5, 7, 10은 질문
        GenerateData();
    }

    public void GenerateData()
    {
        talkData.Add((1, "아..안녕하세요! 처음 뵙겠습니다.", 0));
        talkData.Add((1, "저는 대구를 대표하는 수달 \n‘달쑤’라고 합니다..", 3));
        talkData.Add((1, "……", 3));
        talkData.Add((1, "저희 대구를 도와주세요!!!!", 8));
        talkData.Add((1, "저는 대구를 멋진 도시로 만들고 \n싶은데 혼자서는 무리일 것 같아서.. \n이렇게 간절히 요청드립니다..!", 5));

        talkData.Add((1, "감사합니다! 그럼 이번에는 \n당신에 대해 알아보도록 하죠", 4));
        talkData.Add((1, "제가 감히 뭐라고 불러드리면 \n좋을까요?", 7));
        //talkData.Add((1, string.Format("{0} 맞으신가요?", UD.nickname), 7));

        talkData.Add((1, "{0}님의 명성은 많이 들었습니다. \n손을 댔다 하면 도시를 명소로\n만드는...! 전설적인 컨설턴트시잖아요", 6));
        talkData.Add((1, "기원전에는 이집트 출장도 \n가셨다면서요?", 6));
        talkData.Add((0, "응?", 0));
        talkData.Add((1, "사각뿔 모양의 무덤을 만들어라! \n크으, 그런 생각은 어떻게 하신\n거예요?", 6));
        talkData.Add((0, "...지금 피라미드 얘기하는 거야?", 0));
        talkData.Add((1, "네! 그뿐인가요? 이탈리아에서는 탑을 살짝 기울어지게 지어보는 건 \n어떻겠느냐, 라고 하셔서 또 하나의 명소를 만드셨구요. 얼마 전에 출장 차 방문했는데 지금까지도 관광객들이 바글바글해요!", 6));
        talkData.Add((0, "그건 과장된 소문이지. 당연하잖아?", 0));
        talkData.Add((1, "...믿었는데...", 2));
        talkData.Add((1, "그, 그치만 이런 일화들이 아니더라도 \n{0}님이 커리어가 탄탄하신 건 사실이니까요.", 9));
        talkData.Add((1, "대구에도 {0}님이 꼭 필요합니다! 도와주실 거죠?", 10));
        talkData.Add((1, "그럼 잘 부탁드립니다. 일단 대구로 가볼까요?", 4));
    }

    public void Next()
    {

        if (num < talkData.Count)
        {           
            (talker, message, type) = talkData[num];
            if (message.Contains("{0}"))
            {
                message = string.Format(message, UD.nickname);
            }
            num++;
            if (talker >= 1) Dalssu.SetActive(true);
            if (talker == 0) User.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Main"); // 원하는 씬 이름으로 수정하세요.
        }

        switch (type)
        {
            case 5:
            case 10:
                answer.SetActive(true);
                break;
            case 7:
                inputbox.SetActive(true);
                break;

        }
    }

    public void Update()
    {
        switch (type)
        {
            case 0:
                image.sprite = shadow;
                break;
            case 3:
                image.sprite = dumb;
                break;
            case 4:
                image.sprite = happy;
                break;
            case 2:
            case 5:
                image.sprite = cry;
                break;
            case 10:
            case 6:
                image.sprite = shinning;
                break;
            case 7:
                image.sprite = quest;
                break;
            case 8:
                image.sprite = wow;
                break;
            case 9:
                image.sprite = hmm;
                break;

        }
    }

}
