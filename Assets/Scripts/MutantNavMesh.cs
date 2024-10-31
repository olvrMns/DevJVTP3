using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MutantNavMesh : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent agent; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
    }

    void Update()
    {
        agent.SetDestination(player.position);
    }
}
