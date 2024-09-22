using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCheck : MonoBehaviour
{
    public string filePath = "/data/data/Hope_Daegue/shared_prefs/SharedPreferences.xml";

    public void OnClick()
    {
        // ���� ���� ���� Ȯ��
        CheckFileExists();
    }

    public void CheckFileExists()
    {

        if (PlayerPrefs.HasKey("nickname"))
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            SceneManager.LoadScene("Start");
        }
    }
}