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

    IEnumerator StartStudent() //3���� ���� �ٸ� ���� ����. Chat ���� ���� [with Student]
    {

        RaiseSortingOrder(1); //Canvas Sorting Order ����

        //�ʻ�ȭ ������ ����. 1000����� �÷��̾�, 2000����� NPC
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(1000 + 4, portraitArr[4]);
        portraitData.Add(2000 + 0, portraitArr[5]);

        //��ũ��Ʈ ���
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "�л�?|2", 0));
        yield return StartCoroutine(Chatting("�ǰ��� �л�|2000", "�����ϴ� �ſ�? �� ���� ������ �ڴ� �ſ�. ���� �ʹٰ��.|0", 0));

        //���� ���
        RaiseSortingOrder(3);
        Reward_Student.onClick.AddListener(() => LowerSortingOrder(3));

        portraitData.Clear(); //Dict�� �־�� �� ����
        LowerSortingOrder(1);
    }

    IEnumerator StartMusicians() //3���� ���� �ٸ� ���� ����. Chat ���� ���� [with Musician]
    {
        RaiseSortingOrder(2); //Canvas Sorting Order ����

        //Ư�� ����. 3000���� ������ NPC
        portraitData.Add(3000 + 0, portraitArr[7]);
        portraitData.Add(2000 + 0, portraitArr[6]);

        yield return StartCoroutine(Chatting("�п� ����|3000", "������ ���ּ���! �л����� �����ϴ� ���̶󱸿�!|0", 1));
        yield return StartCoroutine(Chatting("����ŷ û���|2000", "���⼭�� �Ѱܳ��� ���⼭�� �Ѱܳ���...|0", 1));

        //���� ���
        RaiseSortingOrder(4);
        Reward_Musicians.onClick.AddListener(() => LowerSortingOrder(4));

        portraitData.Clear(); //Dict�� �־�� �� ����
        LowerSortingOrder(2); //Canvas Sorting Order ���� (��ȭâ ������)
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
        else // ����Ʈ�� (teacher)
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

        //�ؽ�Ʈ �� ���ھ� ���
        for (int i = 0; i < script.Length - 2; i++) //script�� ���κ� 2�ڸ��� �ĺ� �ڵ���. ��� X.
        {
            writerText += script[i];
            ChatScript[index].text = writerText;
            yield return null;
        }

        //Ű�� ���� ������ ��� (Coroutine ����)
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

    //Cancas�� ȭ�� ����
    public void RaiseSortingOrder(int index)
    {
        if (index >= 0 && index < canvases.Length)
        {
            int currentOrder = canvases[index].sortingOrder;
            canvases[index].sortingOrder = currentOrder + 10;
        }
        else
        {
            Debug.LogWarning("Canvas sorting ���� - Canvas�� ã�� �� ����");
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
            Debug.LogWarning("Canvas sorting ���� - Canvas�� ã�� �� ����");
        }
    }
}
