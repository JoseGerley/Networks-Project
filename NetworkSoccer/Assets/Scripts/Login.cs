using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : SoccerElement 
{

    public Button jugar;
    private string NickName = "";
    public GameObject inputField;
    public GameObject log;
    public DatosUsuarioController duc;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showAd()
    {
        Process p = new Process();
        p.StartInfo.FileName = @"C:\Users\crisf\source\repos\FINAL\Networks-Project\NetworkSoccer\VideoPlayer\VideoPlayer\VideoPlayer\bin\Debug\VideoPlayer.exe";
        p.Start();
    }

    public void StoreName()
    {
        NickName = inputField.GetComponent<Text>().text;
        duc.setNickName(NickName);
        //app.controller.setName(NickName);
        //app.controller.Conectar();
        //Debug.Log("Tan marica");
        try
        {
            StreamWriter sw = new StreamWriter("Name.txt");
            sw.WriteLine(NickName);
            sw.Close();
        }
        catch
        {

        }

        showAd();
        SceneManager.LoadScene("Game");
        
    }


    public void Salir() {
        Application.Quit();
    }


}
