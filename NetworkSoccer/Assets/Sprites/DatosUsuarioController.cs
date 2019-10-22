using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosUsuarioController : MonoBehaviour
{
    private static string nickname;
    public static DatosUsuarioController duc;

    // Start is called before the first frame update
    void Start()
    {
        
        if (duc == null)
        {
            duc = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            
            Destroy(this);
            //Debug.Log("Se creo");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nickname);
    }

    public string getNickName()
    {
        return nickname;
    }

    public void setNickName(string n)
    {
        nickname = n;
    }
}
