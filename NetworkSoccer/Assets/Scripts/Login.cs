﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : SoccerElement 
{

    public Button jugar;
    private string NickName = "";
    public GameObject inputField;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StoreName()
    {
        Debug.Log("Button clicked");
        NickName = inputField.GetComponent<Text>().text;
        Debug.Log(""+NickName);
        app.controller.setName(NickName);
        app.controller.Conectar();

    }


    public void Salir() {
        Application.Quit();
    }


}