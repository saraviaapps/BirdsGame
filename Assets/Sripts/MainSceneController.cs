using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainSceneController : MonoBehaviour
{
    public static int points;
    public TextMeshProUGUI pointsText;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        NotificationCenter.DefaultCenter().AddObserver(this, "PlayerDead");
    }

    // Update is called once per frame
    void Update()
    {
        if (points >StatePoints.StatePoints1.pointsMaximal)
        {
            pointsText.text = points.ToString();
        }else
        {
            pointsText.text = StatePoints.StatePoints1.pointsMaximal.ToString();
        }
        
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/GameScene");
    }
    
    
    
    void PlayerDead(Notification notification)
    {
        if (points > StatePoints.StatePoints1.pointsMaximal)
        {
            Debug.Log("Max point is max"+StatePoints.StatePoints1.pointsMaximal+"Actual"+points);
            StatePoints.StatePoints1.pointsMaximal = points;
            StatePoints.StatePoints1.Save();
        }
        else
        {
            Debug.Log("Max  is not "+StatePoints.StatePoints1.pointsMaximal+"Actual"+points);
        }
    }
    
    
}
