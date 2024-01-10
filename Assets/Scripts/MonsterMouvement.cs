using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMouvement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;
    public Transform target;

    public bool hasAttacked;

    void Update()
    {
        //agent.SetDestination(target.position);


        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < 0.6f)
        {
            agent.isStopped = true;

            if (!hasAttacked)
            {
                hasAttacked = true;
                animator.SetTrigger("Attack");
            }

        }
        else
        {
            agent.SetDestination(target.position);
            if (!hasAttacked)
            {
                hasAttacked = false;
            }
        }

        float actualSpeed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Speed", actualSpeed);
    }
}
