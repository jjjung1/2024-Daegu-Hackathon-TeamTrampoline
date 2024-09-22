// ��� ��ũ��Ʈ�� '|'�� ������ �� �ȴ�. �����ڷ� ���ǰ� �ִ�.
// C#�� ���漱�� X

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

    IEnumerator StartGame() //3���� ���� �ٸ� ���� �����ϴ�, ��ǻ� main �Լ�
    {
        //�ʻ�ȭ ������ ����
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

        //��ũ��Ʈ ���
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "�����...|1"));
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "�������ΰ�? �ʹ� �������...|1"));
        yield return StartCoroutine(Chatting("�޾�|2000", "!|4"));
        yield return StartCoroutine(Chatting("�޾�|2000", "(÷��))|")); //script �� ���� ����
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "?|4"));
        yield return StartCoroutine(Chatting("�޾�|2000", "��, �˼��մϴ�.|5"));
        yield return StartCoroutine(Chatting("�޾�|2000", "���� ��� ���̰ŵ��.|6"));
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "...���� �����ΰ�.|1"));
        yield return StartCoroutine(Chatting("�޾�|2000", "���� Ư���� ������... ����鵵 ���� ���Ϳ�!|0"));
        yield return StartCoroutine(Chatting("�޾�|2000", "ö��3�� ��⵵ �ٷ� ���⼭ �Ѵٱ���.|7"));
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "ö�� 3�� ��⵵?|0"));
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "�׷�, ���� ���ƺ��̱� �Ѵ�.|2"));
        yield return StartCoroutine(Chatting("�޾�|2000", "��. ��õ�� ���� ���� ���Եż� ����õ���� ��ȯ�ϰ� �־��.|6"));
        yield return StartCoroutine(Chatting("�޾�|2000", "�׷���... �̷��� ���� �������ε�...|2"));
        yield return StartCoroutine(Chatting("�޾�|2000", "�ʹ� ����� �� ���� �ʾƿ�?|3"));
        yield return StartCoroutine(Chatting("�޾�|2000", " �� �� ���ۺ��������� ���ڴµ�, ��簡 ������ �ƹ��� �� �´ٱ���.|1"));
        yield return StartCoroutine(Chatting("�޾�|2000", "���ϸ��� �͵� ���� ���ε�...|1"));
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "...|1"));
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "...|2"));
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "�ʵ� ���� �ȸ��� ���屸��.|3"));
        yield return StartCoroutine(Chatting("�޾�|2000", "��?|5"));
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "���� ���̰ŵ�.|3"));
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "������� ���⿡ ���� �𿩼� ��� �ִ� �̷���.|3"));
        yield return StartCoroutine(Chatting("�޾�|2000", "�� ����...|6"));
        yield return StartCoroutine(Chatting("�÷��̾�|1000", "������ �����ٰ�. �̹� �Ƿڵ�.|2"));


        LowerSortingOrder(1); //Canvas Sorting Order ���� (��ȭâ ������)
        RaiseSortingOrder(2); //Canvas Sorting Order ���� (Clear ȭ�� ����)
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
            // NPC�� ������ �� �ۼ� ����!!

        }

        //�ؽ�Ʈ �� ���ھ� ���
        for (int i = 0; i < script.Length - 2; i++) //script�� ���κ� 2�ڸ��� �ĺ� �ڵ���. ��� X.
        {
            writerText += script[i];
            ChatScript.text = writerText;
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
