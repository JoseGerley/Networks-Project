using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller1 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Quaternion rot;
    private Vector2 velocity;
    private Vector2 move { get; set; }
    //public Text countText;
    //public Text winText;

    public float speed;
    //private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rot = new Quaternion();
        move = new Vector2(0, 0);
        //count = 0;
        //winText.text = "";
        //SetCountText();
        velocity = rb2d.velocity;
    }

    void Update()
    {
        rb2d.transform.rotation = rot;
        velocity = rb2d.velocity;
        gameObject.GetComponent<Animator>().SetFloat("speedX", velocity.x);
        if (velocity.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }

        gameObject.GetComponent<Animator>().SetFloat("SpeedY", velocity.y);

    }

    public void setMove(Vector2 v)
    {
        move = v;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(move * speed);
    }

    public void Stop()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
}
