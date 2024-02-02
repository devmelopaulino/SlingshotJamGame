using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Move : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Enemy_Props props;
    [SerializeField] public bool arrive;
    [SerializeField] private bool can_arrive = false;
    [SerializeField] public bool can_move = true;
    private void Start()
    {
        StartCoroutine(WaitFrames());
    }
    private void Update()
    {
        agent.destination = props.player.position;
        arrive = agent.remainingDistance <= agent.stoppingDistance && can_arrive;
        if(can_move)
        {
            agent.isStopped = false;
        }
        else
        {
            agent.isStopped = true;
        }
    }
    private IEnumerator WaitFrames()
    {
        yield return new WaitForSeconds(0.2f);
        can_arrive = true;
    }
}
