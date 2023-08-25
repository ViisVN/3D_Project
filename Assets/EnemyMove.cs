using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    private bool Ismoveable=false;
    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        StartCoroutine(CountDown(5));
        
        if(Ismoveable)
        {
            agent.SetDestination(CharacteMove.Instance.gameObject.transform.position);
        }
    }
    private IEnumerator CountDown(float Time)
    {
        yield return new WaitForSeconds(Time);
        Ismoveable = true;
    }
}
