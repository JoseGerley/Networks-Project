using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarGoles : MonoBehaviour
{
    private static IList<string> historial;
    private static int golesRojo;
    private static int golesAzul;
    public static GuardarGoles gg;
    private static int win;

    // Start is called before the first frame update
    void Awake()
    {

        if (gg == null)
        {
            gg = this;
            DontDestroyOnLoad(gameObject);
            historial = new List<string>();
            win = 1;
            Debug.Log("Se remplazo");
        }
        else 
        {
            Destroy(this);
            Debug.Log("Se creo");
        }
       
    }

    public int blueWin()
    {
        return win;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(historial == null)
        {
            
        }
    }

    public void addGoal(string a, bool isBlue)
    {
        historial.Add(a);
        if (isBlue)
            golesAzul++;
        else
            golesRojo++;
    }

    public List<string> info()
    {
        List<string> msj = new List<string>();
        if (golesRojo == golesAzul)
            msj.Add("Empate");
        else
        {
            if (golesAzul < golesRojo)
            {
                msj.Add("Derrota");
                win = 0;
            }
            else
            {
                msj.Add("Victoria");
                win = 2;
            }

        }
        foreach(string a in historial){
            msj.Add(a);
        }
        return msj;
    }
}
