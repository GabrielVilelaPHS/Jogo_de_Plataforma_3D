using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    public Transform[] destPoints; //vetor de transform "pontos de destino"
    private NavMeshAgent agent;
    private Animator animator;
    private int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destPoints[index].position);
        
    }

    // Update is called once per frame
    void Update() 
    {
        if (agent.remainingDistance < 0.5F){
            index++;
            if (index >= destPoints.Length) index = 0;

            agent.SetDestination(destPoints[index].position);
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Jogador")){
            animator.SetBool("attack", true);
        } else {
            animator.SetBool("attack", false);
        }
    }
}
