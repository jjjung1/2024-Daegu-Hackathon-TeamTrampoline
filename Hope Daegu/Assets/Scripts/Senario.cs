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
        type = 0; //1�� ����, 2�� ���� �۾�
        // 0�� �׸��� ���޼�
        // 3�� ��û ���޼�
        // 4�� ���� ���޼�
        // 2, 5�� ��� ���޼�
        // 6, 10�� ��¦��¦ ���޼�
        // 7�� ? ���޼�
        // 8�� �� ���޼�
        // 9�� ���� ���޼�
        // 5, 7, 10�� ����
        GenerateData();
    }

    public void GenerateData()
    {
        talkData.Add((1, "��..�ȳ��ϼ���! ó�� �˰ڽ��ϴ�.", 0));
        talkData.Add((1, "���� �뱸�� ��ǥ�ϴ� ���� \n���޾������ �մϴ�..", 3));
        talkData.Add((1, "����", 3));
        talkData.Add((1, "���� �뱸�� �����ּ���!!!!", 8));
        talkData.Add((1, "���� �뱸�� ���� ���÷� ����� \n������ ȥ�ڼ��� ������ �� ���Ƽ�.. \n�̷��� ������ ��û�帳�ϴ�..!", 5));

        talkData.Add((1, "�����մϴ�! �׷� �̹����� \n��ſ� ���� �˾ƺ����� ����", 4));
        talkData.Add((1, "���� ���� ����� �ҷ��帮�� \n�������?", 7));
        //talkData.Add((1, string.Format("{0} �����Ű���?", UD.nickname), 7));

        talkData.Add((1, "{0}���� ���� ���� ������ϴ�. \n���� ��� �ϸ� ���ø� ��ҷ�\n�����...! �������� ������Ʈ���ݾƿ�", 6));
        talkData.Add((1, "��������� ����Ʈ ���嵵 \n���̴ٸ鼭��?", 6));
        talkData.Add((0, "��?", 0));
        talkData.Add((1, "�簢�� ����� ������ ������! \nũ��, �׷� ������ ��� �Ͻ�\n�ſ���?", 6));
        talkData.Add((0, "...���� �Ƕ�̵� ����ϴ� �ž�?", 0));
        talkData.Add((1, "��! �׻��ΰ���? ��Ż���ƿ����� ž�� ��¦ �������� ����� �� \n��ڴ���, ��� �ϼż� �� �ϳ��� ��Ҹ� ����̱���. �� ���� ���� �� �湮�ߴµ� ���ݱ����� ���������� �ٱ۹ٱ��ؿ�!", 6));
        talkData.Add((0, "�װ� ����� �ҹ�����. �翬���ݾ�?", 0));
        talkData.Add((1, "...�Ͼ��µ�...", 2));
        talkData.Add((1, "��, ��ġ�� �̷� ��ȭ���� �ƴϴ��� \n{0}���� Ŀ��� źź�Ͻ� �� ����̴ϱ��.", 9));
        talkData.Add((1, "�뱸���� {0}���� �� �ʿ��մϴ�! �����ֽ� ����?", 10));
        talkData.Add((1, "�׷� �� ��Ź�帳�ϴ�. �ϴ� �뱸�� �������?", 4));
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
            SceneManager.LoadScene("Main"); // ���ϴ� �� �̸����� �����ϼ���.
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
