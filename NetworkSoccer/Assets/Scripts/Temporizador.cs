using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public static float inicio = 60f;
    public ReOrganizar reorg;
    private float count;
    public Text contador;
    private bool st;
    private bool iniciar;
    private int addsTimes;
    private int tad = (int)Random.Range(30f, 50f);

    public void showAd()
    {
        addsTimes = 0;
        Process p = new Process();
        p.StartInfo.FileName = @"C:\Users\crisf\Downloads\Networks-Project\Networks-Project\NetworkSoccer\VideoPlayer\VideoPlayer\VideoPlayer\bin\Debug\VideoPlayer.exe";
        p.Start();
    }
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log(tad);
        count = inicio;
        st = false;
        iniciar = false;
        contador.text = "Wait";
    }

    public void setTime(float t)
    {
        count = t;
    }

    public bool isST()
    {
        return st;
    }

    // Update is called once per frame
    void Update()
    {
        
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    iniciar = true;
        //    seguir();
        //}
        if (!iniciar)
        {
            parar();
        }
        if (iniciar)
        {
            count -= Time.deltaTime;
            if (st)
            {
                if (count >= 0)
                {
                    contador.text = "" + count.ToString("f0");
                }
                else
                {
                    contador.text = "finish";
                    parar();
                    if(addsTimes == 1)
                    {
                        showAd();
                        addsTimes++;
                    }
                        

                    SceneManager.LoadScene("DatosPartido");
                }
            }
            else
            {
                if (count >= 0)
                {
                    contador.text = "" + count.ToString("f0");
                    if((int)count==tad && addsTimes == 0)
                    {
                        UnityEngine.Debug.Log(tad);
                        showAd();
                        addsTimes++;
                    }
                }
                else
                {
                    contador.text = "Break";
                    parar();
                    if (count < -5)
                    {
                        begin();
                        st = true;
                        seguir();
                    }

                }
            }
        }
        
           
    }

    public void setBegin(bool t)
    {
        iniciar = t;
        seguir();
    }

    private void begin()
    {
        count = inicio;
    }
    private void parar()
    {
        reorg.Organizar();
        reorg.stop();

    }
    public int getTime()
    {
        return (int)(count+1);
    }

    private void seguir()
    {
        reorg.go();
        //begin();
    }

    public void restart()
    {
        count = inicio;
        st = false;
        iniciar = false;
        contador.text = "Wait";

    }

    public void waiting()
    {
        iniciar = false;
        contador.text = "Wait";
    }

    public void setST(bool s)
    {
        st = s;
    }

    


}
