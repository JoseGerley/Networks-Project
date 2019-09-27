using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalonController : MonoBehaviour
{
    public ReOrganizar organizador;
    public Text RedScore;
    public Text BlueScore;
    private int goalred;
    private int goalblue;
    private Rigidbody2D rb2d;
    public GuardarGoles hist;
    public Temporizador temp;
    // Start is called before the first frame update
    void Start()
    {
        goalblue = 0;
        goalred = 0;
        rb2d = GetComponent<Rigidbody2D>();
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
            goalred ++;
            hist.addGoal(this.gol(false, temp.isST()), false);
            Point();
        }
        if (other.gameObject.CompareTag("GoalZoneBlue"))
        {
            goalblue++;
            hist.addGoal(this.gol(true, temp.isST()), true);
            
            Point();
        }
        
    }

    public void Point()
    {
        SetText();
        organizador.Organizar();
        rb2d.velocity = new Vector2(0, 0);
        rb2d.transform.rotation = new Quaternion();
        
    }

    private void SetText()
    {
        RedScore.text = goalred.ToString();
        BlueScore.text = goalblue.ToString();
    }

    private string gol(bool isBlue, bool isST)
    {
        string msj = "";
        if(isBlue)
            msj += "Equipo Azul '"+temp.getTime()+"' ";
        else
            msj += "Equipo Rojo '" + temp.getTime() + "' ";

        if (isST)
            msj += "T2";
        else
            msj += "T1";

        return msj;
    }
}
