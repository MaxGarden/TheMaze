using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    void Start() { Time.timeScale = 1; }
    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
