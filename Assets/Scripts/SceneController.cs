using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake(){ //serve para transferir a instancia do proprio componente. 
                          //Ou seja, tenho acesso a classe de forma externa
        instance = this;
    }

    public void LoadScene(string scene){
        SceneManager.LoadScene(scene);
    }

    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
