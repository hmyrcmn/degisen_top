using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;

    public GameObject canvasPause;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
             Resume();
            }

            else{
             Pause();
            }
        }
        
    }

    public void Resume(){
     canvasPause.SetActive(false);
     Time.timeScale = 1f;
     isPaused = false;
    }

    public void Pause(){
     canvasPause.SetActive(true);
     Time.timeScale = 0f;
     isPaused = true;
    }

    public void RestartGame(){
        Scene scene;
        scene =SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }
}