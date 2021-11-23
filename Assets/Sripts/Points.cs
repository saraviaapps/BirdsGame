using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    
    public static int points;
    
    // Start is called before the first frame update
    void Start()
    {
       points = 0;
        NotificationCenter.DefaultCenter().AddObserver(this, "PlayerDead");
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text=points.ToString();
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
