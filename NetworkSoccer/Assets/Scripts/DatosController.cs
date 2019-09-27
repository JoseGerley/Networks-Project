using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DatosController : MonoBehaviour
{
    [SerializeField]
    private GameObject text;
    private List<GameObject> textItems;
    public GuardarGoles gg;
    private IList<string> lista;
    
    public void LogText(string nextstring)
    {
        GameObject newT = Instantiate(text) as GameObject;
        newT.SetActive(true);

        newT.GetComponent<TextLogItem>().SetText(nextstring);
        newT.transform.SetParent(text.transform.parent, false);

        textItems.Add(newT.gameObject);
        
    }
    
    public void UpdateItems()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        textItems = new List<GameObject>();
        lista = gg.info();
        for(int i=1; i < lista.Count(); i++)
        {
            this.LogText(lista.ElementAt(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
