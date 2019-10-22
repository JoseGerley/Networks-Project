using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public Image p1;
    public Image p2;
    public Text text;
    public GuardarGoles gg;
    // Start is called before the first frame update
    void Start()
    {
        text.text = gg.info()[0];
        if (gg.blueWin() == 0)
        {
            p1.enabled = false;
            text.color = Color.red;
        }
        if (gg.blueWin() == 1)
        {
            
        }
        if (gg.blueWin() == 2)
        {
            text.color = Color.blue;
            p2.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
