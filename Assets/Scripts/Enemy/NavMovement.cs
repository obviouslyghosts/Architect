using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMovement : MonoBehaviour
{
  private Transform target;
  private NavMeshAgent navMeshAgent;

  private void Start()
  {
    navMeshAgent = this.GetComponent<NavMeshAgent>();
    if ( navMeshAgent == null )
    {
      Debug.LogError( "No NavMeshAgent Component attached: " + gameObject.name );
    }
    else
    {
      SetDestination();
    }
  }

  private void Update()
  {
    if ( target != null )
    {
      navMeshAgent.SetDestination( target.position );
    }
  }

  private void SetDestination()
  {
    GameObject[] allTargets = GameObject.FindGameObjectsWithTag( "ChaseTarget" );
    Debug.Log( allTargets );
    if ( allTargets.Length > 0 )
    {
      // Debug.Log( allTargets[0].gameObject.name );
      target = allTargets[0].gameObject.transform;
      // navMeshAgent.SetDestination( allTargets[0].gameObject.transform.position );
    }
  }

}
