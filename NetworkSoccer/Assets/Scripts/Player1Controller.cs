using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour
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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        move = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(move * speed);
    }

    public Vector2 getMove()
    {
        return move;
    }


    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

    }

    private void SetCountText()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= 12)
        {
            winText.text = "YOU WIN!!";
        }
    }
    */
}
