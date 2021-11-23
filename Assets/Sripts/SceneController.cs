using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public GameObject canvasLose;
    public GameObject canvasResume;
    public Image imagePause;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Scenes/GameScene");
            imagePause.enabled = true;
        }
    }

    public void Lose()
    {
        
        canvasLose.SetActive(true);
        imagePause.enabled = false;
        Time.timeScale = 0;
        NotificationCenter.DefaultCenter().PostNotification(this, "PlayerDead");
    }
    
    
    public void RestartGame()
    {
        SceneManager.LoadScene("Scenes/GameScene");
        imagePause.enabled = true;
    }
    
    public void PauseGame()
    {
        canvasLose.SetActive(false);
        canvasResume.SetActive(true);
        imagePause.enabled = false;
        Time.timeScale = 0;
    }
    
    
    public void ResumeGame()
    {
        canvasResume.SetActive(false);
        imagePause.enabled = true;
        Time.timeScale = 1;
    }
    
    
    public void MainMenu()
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "PlayerDead");
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    
}
