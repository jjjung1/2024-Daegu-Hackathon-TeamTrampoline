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
        // ���� ��θ� ����ϰų� Application.persistentDataPath ���� Unity ��θ� ����� �� �ֽ��ϴ�.
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
