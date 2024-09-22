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
        // 절대 경로를 사용하거나 Application.persistentDataPath 같은 Unity 경로를 사용할 수 있습니다.
        string fullPath = Path.Combine(Application.persistentDataPath, filePath);

        if (File.Exists(fullPath))
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            SceneManager.LoadScene("Start");
        }
    }
}
