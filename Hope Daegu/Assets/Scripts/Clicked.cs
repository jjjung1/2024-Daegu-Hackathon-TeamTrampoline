using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Clicked : MonoBehaviour
{
    public GameObject answer;
    public UserDatas UDs;
    public DalssuTalk DT;
    public talking talk;
    public TextMeshProUGUI text;

    public TextMeshProUGUI at1;
    public TextMeshProUGUI at2;

    public void Awake()
    {
        at1.text = "����";
        at2.text = "������";
    }
    public void OnClicked()
    {
        if(text.text == "����")
        {
            answer.SetActive(false);
            DT.talkData.Add(("���ƿ�! ���ݱ�����(�г���)���� ���� �ϻ��� �ϳ��ϳ� ����صѰԿ�!", 2));
            DT.talkData.Add(("�Ϸ��߽��ϴ�! �����ε� �������̿���!", 1));
            DT.Next();
            PlayerPrefs.SetString("nickname", UDs.nickname);
            PlayerPrefs.SetInt("power_max", UDs.power_max);
            PlayerPrefs.SetInt("power_percent", UDs.power_percent);
            PlayerPrefs.SetInt("money", UDs.money);
            string json = JsonUtility.ToJson(new Serialization<string>(UDs.inventory));
            PlayerPrefs.SetString("inventory", json);
            PlayerPrefs.Save();


        }
        else if(text.text == "������")
        {
            answer.SetActive(false);
            DT.talkData.Add((string.Format("���� ���ô� �ǰ��� �Ф� ���� ���� �뱸�� {0}���� ������ �ʿ��ؿ�", UDs.nickname), 3));
            at1.text = "���� ��";
            at2.text = "�˾Ҿ�.. �Ȱ���";
            DT.Next();
            answer.SetActive(true);

        }
        else if(text.text == "���� ��")
        {
            answer.SetActive(false);
            DT.talkData.Add((string.Format("��¿ �� ���׿�.. �ƽ����� ���� �������� ��ٸ��� �ְڽ��ϴ١� ", UDs.nickname), 4));
            DT.Next(); 
        }
        else if(text.text == "�˾Ҿ�.. �Ȱ���")
        {
            talk.gameObject.SetActive(false);
        }
    }
}
