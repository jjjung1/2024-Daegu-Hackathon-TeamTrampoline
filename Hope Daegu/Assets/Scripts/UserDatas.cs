using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserDatas : MonoBehaviour
{
    public static UserDatas Instance;

    public bool newone;

    public string nickname;
    public int power_max = 100;
    public int power_percent = 80;
    public int money = 1500;
    public List<string> inventory;




    // Start is called before the first frame update
    void Awake()
    {
      

        if (PlayerPrefs.HasKey("nickname"))
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

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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