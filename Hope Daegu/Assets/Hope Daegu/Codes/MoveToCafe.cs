using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToCafe : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Cafe");
    }
}