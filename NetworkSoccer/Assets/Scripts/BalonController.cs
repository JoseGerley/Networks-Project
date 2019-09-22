using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalonController : SoccerElement
{
    public Text RedScore;
    public Text BlueScore;
    private int goalred;
    private int goalblue;
    // Start is called before the first frame update
    void Start()
    {
        goalblue = 0;
        goalred = 0;
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GoalZoneRed"))
        {
            goalblue ++;
        }
        if (other.gameObject.CompareTag("GoalZoneBlue"))
        {
            goalred++;
        }
        SetText();
    }

    private void SetText()
    {
        RedScore.text = goalred.ToString();
        BlueScore.text = goalblue.ToString();
    }
}
