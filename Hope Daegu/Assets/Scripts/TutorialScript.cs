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
        message = "�뱸�� ���� �� ȯ���մϴ�! ���, ������?";
        type = 0; 
        // 0�� ���� ���޼�
        // 1�� ��� ���޼�
        // 2�� ��¦��¦ ���޼�
        // 3�� ���� ���޼�
        GenerateData();
    }
    public void GenerateData()
    {
        talkData.Add((string.Format("���ݵ� ����� �������� {0}�Բ��� �� ���� �뱸�� ������ֽǰŶ� �� �Ͼ��", UDs.nickname), 2));
        talkData.Add(("�� ���� �ƽ��� ���� ��ĥ ���� ���� �ż� �� ������ ����� '������� ���� ��'������¦��¦�� ��'�ۿ� �� �� �����.", 1));
        talkData.Add(("������ ���鵵 ���� ���� �������� �ϴ� ���� �� �� �ִ� ������ �鷯����..!", 0));
        talkData.Add(("�������� ���Ͻô� ���� ���� �� �� �־��! ������ �ܵ� 1500��!", 2));
        talkData.Add(("�׷��� ù �̵���ŭ�� �������� ���ö�� ���� �̸� �Ҹųֱ⸦ �� �س�����", 3));
        talkData.Add(("���� �뱸�� ���� �����ֽô� �� ������ �ƹ����� �ʹ� ������ �Ͻôٺ��� �Ƿε��� �ٴڳ� �� ������ �̸��̸� ������ �Ծ�δ� �� ���ƿ�", 2));
        talkData.Add(("�׷� ���� �������? ����� ����ٸ� �� �޾����� ���� �ɾ��ּ���! ", 0));
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
            gameObject.SetActive(false); // ���ϴ� �� �̸����� �����ϼ���.
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
