using UnityEngine;

public class BGMController : MonoBehaviour
{
    private static BGMController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� ��ü ����
        }
    }

    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; // ���� �ݺ� ����
        audioSource.Play();
    }
}