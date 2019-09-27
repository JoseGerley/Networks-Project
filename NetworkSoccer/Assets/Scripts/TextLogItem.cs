using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLogItem : MonoBehaviour
{

    public void SetText(string s)
    {
        GetComponent<Text>().text = s;
        //GetComponent<Text>().color = c;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
