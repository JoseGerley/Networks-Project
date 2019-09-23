using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerView : SoccerElement
{
    public Player1Controller p1;
    public Player2Controller1 p2;

    public Player1Controller getP1()
    {
        return p1;
    }

    public Player2Controller1 getP2()
    {
        return p2;
    }
}
