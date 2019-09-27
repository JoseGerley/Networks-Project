using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public static float inicio = 10f;
    public ReOrganizar reorg;
    private float count;
    public Text contador;
    private bool st;
    private bool iniciar;
    // Start is called before the first frame update
    void Start()
    {
        count = inicio;
        st = false;
        iniciar = false;
        contador.text = "Wait";
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
                    SceneManager.LoadScene("DatosPartido");
                }
            }
            else
            {
                if (count >= 0)
                {
                    contador.text = "" + count.ToString("f0");
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
        return (int)count;
    }

    private void seguir()
    {
        reorg.go();
        begin();
    }




}
