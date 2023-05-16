using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3 (13,30,45) * Time.deltaTime); //deltaTime cria a suavização. Tem o mesmo comportamento ideepnedente da quantidade de frame usado no jogo
    }
}
