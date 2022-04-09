using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string nameOfTheSceneToLoad = "";

    public void loadLevel()
    {
        SceneManager.LoadScene(nameOfTheSceneToLoad);
    }
}
