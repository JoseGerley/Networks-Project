using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : SoccerElement
{
    private Rigidbody2D rb2d;
    private Vector2 move;

    //public Text countText;
    //public Text winText;

    public float speed;
    //private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        move = new Vector2(0, 0);
        //count = 0;
        //winText.text = "";
        //SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(move * speed);
    }

    public void setMove(Vector2 v)
    {
        move = v;
    }
}
