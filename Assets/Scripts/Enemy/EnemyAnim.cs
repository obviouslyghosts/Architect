using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
  // public Rigidbody rigidBody;

  public Animator anim;
  // public NavMeshAgent agent;
  private Vector3 lastPos;

  private void Start()
  {
    // agent.updatePosition = false;
    lastPos = gameObject.transform.position;
  }

  private void Update()
  {
    float s = Vector3.Distance(lastPos, gameObject.transform.position) / Time.deltaTime;

    lastPos = gameObject.transform.position;
    anim.SetFloat("Speed", s);
    // Debug.Log( s );
  }

  public void SetAttack( bool v )
  {
    anim.SetBool( "Attacking", v );
  }

}
