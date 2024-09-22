using UnityEngine;

public class BGMController : MonoBehaviour
{
    private static BGMController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복 객체 제거
        }
    }

    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; // 무한 반복 설정
        audioSource.Play();
    }
}