using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class NivelController : MonoBehaviour
{

    public static NivelController instance;

    public int totalitens;
    private int itenscoletados;
    // Start is called before the first frame update
    
    public TextMeshProUGUI textoPontos;
    public TextMeshProUGUI textoTotal;
    private bool win;

    void Awake() {
        instance = this;
    }
    void Start()
    {
        textoPontos.text = "Itens Coletados: 0" + itenscoletados;
        win = false;
    }

    public void SetItensColetados()
    {
        itenscoletados++;
        textoPontos.text = "Itens Coletados: 0" + itenscoletados;
    
        if (itenscoletados >= totalitens) {win = true;}
    }

    public bool GetWin(){

        return win;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
