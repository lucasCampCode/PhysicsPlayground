using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    public int sceneIndex = 0;

    public void GoToSpecificScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
