using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    NavMeshAgent agent;      
    Animator anim;          
    State currentState;      

    public Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();    
        anim = GetComponent<Animator>();        
        currentState = new Idle(gameObject, agent, anim, player); 
    }

    // Mise à jour à chaque frame pour traiter l'état actuel
    void Update()
    {
        currentState = currentState.Process(); // Mise à jour de l'état actuel du NPC
    }
}
