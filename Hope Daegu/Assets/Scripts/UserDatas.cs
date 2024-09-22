using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserDatas : MonoBehaviour
{
    public bool newone;

    public string nickname;
    public int power_max = 100;
    public int power_percent = 80;
    public int money = 1500;
    public List<string> inventory; 
 

    

    // Start is called before the first frame update
    void Awake()
    {
        string filePath = "/data/data/Hope_Daegue/shared_prefs/SharedPreferences.xml";
        string fullPath = Path.Combine(Application.persistentDataPath, filePath);
        if (File.Exists(fullPath))
        {
            newone = false;
        }
        else
        {
            newone = true;
        }
        nickname = PlayerPrefs.GetString("nickname", UserData.Instance.nickname);
        power_max = PlayerPrefs.GetInt("power_max", 100); 
        power_percent = PlayerPrefs.GetInt("power_percent", 80);
        money = PlayerPrefs.GetInt("money", 1500);
        string json = PlayerPrefs.GetString("inventory", "{}");
        Serialization<string> serialization = JsonUtility.FromJson<Serialization<string>>(json);
        List<string> inventory = serialization.target;

    }


}


[System.Serializable]
public class Serialization<T>
{
    public List<T> target;

    public Serialization(List<T> target)
    {
        this.target = target;
    }
}
