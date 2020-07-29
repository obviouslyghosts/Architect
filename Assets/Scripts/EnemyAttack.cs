using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

  public EnemyAnim enemyAnim;

  private void OnTriggerEnter(Collider other)
  {
    if ( other.gameObject.tag == "Player" )
    {
      enemyAnim.SetAttack( true );// anim.SetBool( "Attacking", true );
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if ( other.gameObject.tag == "Player" )
    {
      enemyAnim.SetAttack( false );// anim.SetBool( "Attacking", true );

      // enemyAnim.SetBool( "Attacking", false );
    }
  }

}
