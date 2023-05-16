using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private Rigidbody rg;
    private Animator animator;
    private AudioSource audio;
    public float velocidade;
    public GameObject Item_Particula;
    private bool isDead;
    public AudioClip itens, win, dead;
    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate(){ //usado para trabalhar com os componentes da fisica será o FixedUpdate

        if (isDead) return;

        float  horizontal = Input.GetAxis("Horizontal");
        float  vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0){
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
        Vector3 movimento = new Vector3(horizontal,0,vertical);
        rg.AddForce(movimento * velocidade); //(x,y,z)

        if(movimento != Vector3.zero){ // ou seja, teve alteração no Vector3
            transform.rotation = Quaternion.LookRotation(movimento); //vai rotacionar para onde estiver olhando, ou seja, o moimento

        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("item")){
            Instantiate(Item_Particula, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

            NivelController.instance.SetItensColetados();
            PlayAudio(itens);

            if (NivelController.instance.GetWin()) Win();

        }
        else if(other.gameObject.CompareTag("Inimigo")){
            Instantiate(Item_Particula, other.gameObject.transform.position, Quaternion.identity);
            Death();
        }

    }

    private void Death(){
        isDead = true;
        Destroy(gameObject);
        PlayAudio(dead);
        Invoke("ReloadScene", 3F); //chama ReloaodScene depois de 3 segundos
    }

    private void Win(){
        animator.SetBool("win", true);
        PlayAudio(win);
         Invoke("LoadScene", 3F);
    }

    private void PlayAudio(AudioClip clip){
        audio.clip = clip;
        audio.Play();
    }

    private void ReloadScene(){
        SceneController.instance.ReloadScene();
    }

    private void LoadScene(){
        SceneController.instance.LoadScene(scene);
    }

}
