using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButtonHandler : MonoBehaviour
{
    public void PlayAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlayAgain();
        }
    }
}
