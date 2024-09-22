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
        // 파일 존재 여부 확인
        CheckFileExists();
    }

    public void CheckFileExists()
    {

        if (PlayerPrefs.HasKey("nickname") && PlayerPrefs.GetString("nickname") != null)
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Start");
        }
    }
}