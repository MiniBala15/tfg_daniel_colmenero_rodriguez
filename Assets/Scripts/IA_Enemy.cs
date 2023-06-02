using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Enemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    public NavMeshAgent IA;

    void Update()
    {
        IA.speed = speed;
        IA.SetDestination(target.position);        
    }
}
