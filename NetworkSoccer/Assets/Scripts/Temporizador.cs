using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : SoccerElement
{
    private float count;
    public Text contador;

    // Start is called before the first frame update
    void Start()
    {
        count = 60f;
        contador.text = "" + count;
    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
        contador.text = "" + count.ToString("f0");
    }
}
