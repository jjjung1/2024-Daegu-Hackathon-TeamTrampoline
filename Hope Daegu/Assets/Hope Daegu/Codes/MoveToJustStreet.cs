using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToJustStreet : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("JustStreet");
    }
}