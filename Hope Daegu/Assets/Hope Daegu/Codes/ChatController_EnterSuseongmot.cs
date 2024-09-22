// 출력 스크립트에 '|'가 들어가서는 안 된다. 구분자로 사용되고 있다.
// C#은 전방선언 X

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatController_EnterSuseongmot : MonoBehaviour
{
    public Text ChatScript;
    public Text CharacterName;
    public string writerText = "";

    public Image NameBox;
    public Sprite PlayerNameBox;
    public Sprite DalssuNameBox;

    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    public Image portraitImgLeft;
    public Image portraitImgRight;

    public Canvas[] canvases;

    void Start()
    {
        StartCoroutine(StartGame());
    }

    void Awake()
    {
        portraitData = new Dictionary<int, Sprite>();
    }

    IEnumerator StartGame() //3가지 서로 다른 일을 수행하는, 사실상 main 함수
    {
        //초상화 데이터 저장
        portraitData.Add(1000 + 0, portraitArr[9]);
        portraitData.Add(1000 + 1, portraitArr[10]);
        portraitData.Add(1000 + 2, portraitArr[11]);
        portraitData.Add(1000 + 3, portraitArr[12]);
        portraitData.Add(1000 + 4, portraitArr[13]);
        portraitData.Add(2000 + 0, portraitArr[0]);
        portraitData.Add(2000 + 1, portraitArr[1]);
        portraitData.Add(2000 + 2, portraitArr[2]);
        portraitData.Add(2000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 4, portraitArr[4]);
        portraitData.Add(2000 + 5, portraitArr[5]);
        portraitData.Add(2000 + 6, portraitArr[6]);
        portraitData.Add(2000 + 7, portraitArr[7]);
        portraitData.Add(2000 + 8, portraitArr[8]);

        //스크립트 출력
        yield return StartCoroutine(Chatting("플레이어|1000", "여기는...|1"));
        yield return StartCoroutine(Chatting("플레이어|1000", "저수지인가? 너무 허허벌판...|1"));
        yield return StartCoroutine(Chatting("달쑤|2000", "!|4"));
        yield return StartCoroutine(Chatting("달쑤|2000", "(첨벙))|")); //script 한 글자 씹힘
        yield return StartCoroutine(Chatting("플레이어|1000", "?|4"));
        yield return StartCoroutine(Chatting("달쑤|2000", "앗, 죄송합니다.|5"));
        yield return StartCoroutine(Chatting("달쑤|2000", "자주 놀던 곳이거든요.|6"));
        yield return StartCoroutine(Chatting("플레이어|1000", "...역시 수달인가.|1"));
        yield return StartCoroutine(Chatting("달쑤|2000", "종족 특성은 맞지만... 사람들도 자주 들어와요!|0"));
        yield return StartCoroutine(Chatting("달쑤|2000", "철인3종 경기도 바로 여기서 한다구요.|7"));
        yield return StartCoroutine(Chatting("플레이어|1000", "철인 3종 경기도?|0"));
        yield return StartCoroutine(Chatting("플레이어|1000", "그래, 물이 맑아보이긴 한다.|2"));
        yield return StartCoroutine(Chatting("달쑤|2000", "네. 신천의 맑은 물이 유입돼서 범어천으로 순환하고 있어요.|6"));
        yield return StartCoroutine(Chatting("달쑤|2000", "그런데... 이렇게 좋은 수성못인데...|2"));
        yield return StartCoroutine(Chatting("달쑤|2000", "너무 고요한 것 같지 않아요?|3"));
        yield return StartCoroutine(Chatting("달쑤|2000", " 좀 더 복작복작했으면 좋겠는데, 행사가 없으면 아무도 안 온다구요.|1"));
        yield return StartCoroutine(Chatting("달쑤|2000", "매일매일 와도 좋은 곳인데...|1"));
        yield return StartCoroutine(Chatting("플레이어|1000", "...|1"));
        yield return StartCoroutine(Chatting("플레이어|1000", "...|2"));
        yield return StartCoroutine(Chatting("플레이어|1000", "너도 이제 안목이 생겼구나.|3"));
        yield return StartCoroutine(Chatting("달쑤|2000", "네?|5"));
        yield return StartCoroutine(Chatting("플레이어|1000", "나도 보이거든.|3"));
        yield return StartCoroutine(Chatting("플레이어|1000", "사람들이 여기에 가득 모여서 놀고 있는 미래가.|3"));
        yield return StartCoroutine(Chatting("달쑤|2000", "그 말은...|6"));
        yield return StartCoroutine(Chatting("플레이어|1000", "멋지게 보여줄게. 이번 의뢰도.|2"));


        LowerSortingOrder(1); //Canvas Sorting Order 조절 (대화창 내리기)
        RaiseSortingOrder(2); //Canvas Sorting Order 조절 (Clear 화면 띄우기)
    }

    IEnumerator Chatting(string character, string script)
    {
        CharacterName.text = character.Split('|')[0];
        writerText = "";

        if (int.Parse(character.Split('|')[1]) == 1000)
        {
            NameBox.sprite = PlayerNameBox;

            if (!string.IsNullOrEmpty(script.Split('|')[1]))
            {
                portraitImgLeft.sprite = GetPortrait(int.Parse(character.Split('|')[1]), int.Parse(script.Split('|')[1]));
                portraitImgLeft.color = new Color(1, 1, 1, 1);
            }
            else
            {
                portraitImgLeft.color = new Color(0, 0, 0, 0);
            }
        }
        else if (int.Parse(character.Split('|')[1]) == 2000)
        {
            NameBox.sprite = DalssuNameBox;

            if (!string.IsNullOrEmpty(script.Split('|')[1]))
            {
                portraitImgRight.sprite = GetPortrait(int.Parse(character.Split('|')[1]), int.Parse(script.Split('|')[1]));
                portraitImgRight.color = new Color(1, 1, 1, 1);
            }
            else
            {
                portraitImgRight.color = new Color(0, 0, 0, 0);
            }
        }
        else
        {
            // NPC들 관리할 때 작성 ㄱㄱ!!

        }

        //텍스트 한 글자씩 출력
        for (int i = 0; i < script.Length - 2; i++) //script의 끝부분 2자리는 식별 코드임. 출력 X.
        {
            writerText += script[i];
            ChatScript.text = writerText;
            yield return null;
        }

        //키를 누를 때까지 대기 (Coroutine 관련)
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                break;
            }
            yield return null;
        }
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }

    //Cancas로 화면 관리
    public void RaiseSortingOrder(int index)
    {
        if (index >= 0 && index < canvases.Length)
        {
            int currentOrder = canvases[index].sortingOrder;
            canvases[index].sortingOrder = currentOrder + 10;
        }
        else
        {
            Debug.LogWarning("Canvas sorting 오류 - Canvas를 찾을 수 없음");
        }
    }

    public void LowerSortingOrder(int index)
    {
        if (index >= 0 && index < canvases.Length)
        {
            int currentOrder = canvases[index].sortingOrder;
            canvases[index].sortingOrder = currentOrder - 10;
        }
        else
        {
            Debug.LogWarning("Canvas sorting 오류 - Canvas를 찾을 수 없음");
        }
    }
}
