using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatController_AcademyStreet : MonoBehaviour
{
    public Button Student;
    public Button Musicians;
    public Button Reward_Student;
    public Button Reward_Musicians;

    public Text[] ChatScript;
    public Text[] CharacterName;
    public string writerText = "";

    public Image[] NameBox;
    public Sprite PlayerNameBox;
    public Sprite NPCNameBox;
    public Sprite ExtraNameBox;

    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    public Image[] portraitImgLeft;
    public Image[] portraitImgRight;

    public Canvas[] canvases;

    void Start()
    {
        //StartCoroutine(StartStudent());
       // StartCoroutine(StartMusicians());
        Student.onClick.AddListener(() => StartCoroutine(StartStudent()));
        Musicians.onClick.AddListener(() => StartCoroutine(StartMusicians()));
    }
    void Awake()
    {
        portraitData = new Dictionary<int, Sprite>();
    }

    IEnumerator StartStudent() //3가지 서로 다른 일을 수행. Chat 전반 관리 [with Student]
    {

        RaiseSortingOrder(1); //Canvas Sorting Order 조절

        //초상화 데이터 저장. 1000번대는 플레이어, 2000번대는 NPC
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(1000 + 4, portraitArr[4]);
        portraitData.Add(2000 + 0, portraitArr[5]);

        //스크립트 출력
        yield return StartCoroutine(Chatting("플레이어|1000", "학생?|2", 0));
        yield return StartCoroutine(Chatting("피곤한 학생|2000", "좋아하는 거요? 집 가서 누워서 자는 거요. 쉬고 싶다고요.|0", 0));

        //보상 출력
        RaiseSortingOrder(3);
        Reward_Student.onClick.AddListener(() => LowerSortingOrder(3));

        portraitData.Clear(); //Dict에 넣어둔 거 비우기
        LowerSortingOrder(1);
    }

    IEnumerator StartMusicians() //3가지 서로 다른 일을 수행. Chat 전반 관리 [with Musician]
    {
        RaiseSortingOrder(2); //Canvas Sorting Order 조절

        //특별 예외. 3000번대 뮤지션 NPC
        portraitData.Add(3000 + 0, portraitArr[7]);
        portraitData.Add(2000 + 0, portraitArr[6]);

        yield return StartCoroutine(Chatting("학원 강사|3000", "조용히 해주세요! 학생들이 공부하는 곳이라구요!|0", 1));
        yield return StartCoroutine(Chatting("버스킹 청년들|2000", "여기서도 쫓겨나고 저기서도 쫓겨나고...|0", 1));

        //보상 출력
        RaiseSortingOrder(4);
        Reward_Musicians.onClick.AddListener(() => LowerSortingOrder(4));

        portraitData.Clear(); //Dict에 넣어둔 거 비우기
        LowerSortingOrder(2); //Canvas Sorting Order 조절 (대화창 내리기)
    }

    IEnumerator Chatting(string character, string script, int index)
    {
        CharacterName[index].text = character.Split('|')[0];
        writerText = "";

        if (int.Parse(character.Split('|')[1]) == 1000)
        {
            NameBox[index].sprite = PlayerNameBox;

            if (!string.IsNullOrEmpty(script.Split('|')[1]))
            {
                portraitImgLeft[index].sprite = GetPortrait(int.Parse(character.Split('|')[1]), int.Parse(script.Split('|')[1]));
                portraitImgLeft[index].color = new Color(1, 1, 1, 1);
            }
            else
            {
                portraitImgLeft[index].color = new Color(0, 0, 0, 0);
            }
        }
        else if (int.Parse(character.Split('|')[1]) == 2000)
        {
            NameBox[index].sprite = NPCNameBox;

            if (!string.IsNullOrEmpty(script.Split('|')[1]))
            {
                portraitImgRight[index].sprite = GetPortrait(int.Parse(character.Split('|')[1]), int.Parse(script.Split('|')[1]));
                portraitImgRight[index].color = new Color(1, 1, 1, 1);
            }
            else
            {
                portraitImgRight[index].color = new Color(0, 0, 0, 0);
            }
        }
        else // 엑스트라 (teacher)
        {
            NameBox[index].sprite = ExtraNameBox;

            if (!string.IsNullOrEmpty(script.Split('|')[1]))
            {
                portraitImgLeft[index].sprite = GetPortrait(int.Parse(character.Split('|')[1]), int.Parse(script.Split('|')[1]));
                portraitImgLeft[index].color = new Color(1, 1, 1, 1);
            }
            else
            {
                portraitImgLeft[index].color = new Color(0, 0, 0, 0);
            }
        }

        //텍스트 한 글자씩 출력
        for (int i = 0; i < script.Length - 2; i++) //script의 끝부분 2자리는 식별 코드임. 출력 X.
        {
            writerText += script[i];
            ChatScript[index].text = writerText;
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
