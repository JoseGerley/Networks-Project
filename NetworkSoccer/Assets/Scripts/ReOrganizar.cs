using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReOrganizar : MonoBehaviour
{

    public GameObject  cv;
    public GameObject player;
    public GameObject balon;
    public GameObject player1;
    public GameObject player2;

    public static Vector3 posBaloon = new Vector3(0,0);
    public static Vector3 posP1 = new Vector3(0, -1.555f);
    public static Vector3 posP2 = new Vector3(0,  1.968f);

    public void Organizar()
    {
        
       

        Quaternion rotation = new Quaternion();
        balon.transform.SetPositionAndRotation(posBaloon, rotation);
        player1.transform.SetPositionAndRotation(posP1, rotation);
        player2.transform.SetPositionAndRotation(posP2, rotation);
    }

    public void go() {
        balon.GetComponent<Rigidbody2D>().Sleep();
        player1.GetComponent<Rigidbody2D>().Sleep();
        player2.GetComponent<Rigidbody2D>().Sleep();
    }
    public void stop()
    {
        balon.GetComponent<Rigidbody2D>().WakeUp();
        player1.GetComponent<Rigidbody2D>().WakeUp();
        player2.GetComponent<Rigidbody2D>().WakeUp();
    }



}
