using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReOrganizar : MonoBehaviour
{
    public static Vector3 posBaloon = new Vector3(0f, 0f, 0f);
    public static Vector3 posP1 = new Vector3(0f, -1.45f);
    public static Vector3 posP2 = new Vector3(0f, 1.45f);
    public GameObject balon;
    public GameObject player1;
    public GameObject player2;

    public void Organizar()
    {
        Quaternion rotation = new Quaternion();
        balon.transform.SetPositionAndRotation(posBaloon, rotation);
        player1.transform.SetPositionAndRotation(posP1, rotation);
        player2.transform.SetPositionAndRotation(posP2, rotation);
    }
}
