using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class rock : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 5f;
    public player player;
    // Start is called before the first frame update
    void Start()
    {

        // accessing the player script of player...
        player = GameObject.Find("Player").GetComponent<player>();
        if(player.score>20)
        {
            speed = 10f;
        }
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up*speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float down_ = -camPoint.y;
        if (transform.position.y <= down_ - 5)
        {
            Destroy(gameObject);
        }

    }
   

}
