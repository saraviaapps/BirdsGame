using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 1;
    private Rigidbody2D rb;
    public SceneController Controller;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * speed;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        NotificationCenter.DefaultCenter().PostNotification(this, "PlayerDead");
        
       Controller.Lose();
    }
    
}
