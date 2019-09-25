using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public static float inicio = 60f;
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            iniciar = true;
            seguir();
        }
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

    private void begin()
    {
        count = inicio;
    }
    private void parar()
    {
        reorg.Organizar();
        reorg.stop();

    }
    private void seguir()
    {
        reorg.go();
        begin();
    }




}
