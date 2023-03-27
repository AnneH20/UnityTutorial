using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string gameName;

    public void LoadGame()
    {
        SceneManager.LoadScene(gameName);
    }
}
