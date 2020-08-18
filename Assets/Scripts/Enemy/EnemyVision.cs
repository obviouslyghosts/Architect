using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
  public Vector2 speed = Vector2.one;
  public Vector2 acceleration = Vector2.one;
  public EnemyAnim enemyAnim;
  public NavMeshAgent agent;


  private void OnTriggerEnter(Collider other)
  {
    if ( other.gameObject.tag == "Player" )
    {
      enemyAnim.SetAttack( true );
      agent.speed = speed.y;
      agent.acceleration = acceleration.y;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if ( other.gameObject.tag == "Player" )
    {
      enemyAnim.SetAttack( false );
      agent.speed = speed.x;
      agent.acceleration = acceleration.x;
    }
  }

}
