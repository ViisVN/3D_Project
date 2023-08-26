using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    Transform _mainPos;
    float time;
    float basedtime =5f;
    private bool Ismoveable=false;
    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {    
         time += Time.deltaTime;
        if(time>basedtime)
        {
            agent.SetDestination(CharacteMove.Instance.gameObject.transform.position);
            time =0f;
        }
    }
}
