using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    public string sceneIndex = "";

    public void GoToSpecificScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
