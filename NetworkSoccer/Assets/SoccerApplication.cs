using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerElement : MonoBehaviour
{
    // Da acceso a la aplicación y a todas las instancias.
    public SoccerApplication app { get { return FindObjectOfType<SoccerApplication>(); } }
}

public class SoccerApplication : MonoBehaviour
{
    public SoccerModel model;
    public SoccerView view;
    public SoccerController controller;

    // Init
    void Start() { }
}
