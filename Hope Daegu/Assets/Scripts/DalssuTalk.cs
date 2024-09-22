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
        message = "� ���̽Ű���? ";
        type = 0;
        // 0�� ? ���޼� -> ����/������
        // 1�� �� ���޼� -> ������
        // 2�� ��¦��¦ ���޼�
        // 3�� ��Կ�� ���޼� -> �� / �ƴϿ�
        // 4�� ���� ���޾� -> �ٷ� ������
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
            gameObject.SetActive(false); // ���ϴ� �� �̸����� �����ϼ���.
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
