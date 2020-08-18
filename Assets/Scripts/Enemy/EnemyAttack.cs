using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
  public float attackTimer = 1f;
  public float attackDamage = 5f;
  // private GameObject player;
  private PlayerStatus status;
  private float alarm;

  private void Update()
  {
    alarm = ( alarm > 0 ) ? alarm - Time.deltaTime : 0 ;
  }

  private void OnTriggerStay(Collider other)
  {
    if ( other.gameObject.tag == "Player" & alarm <= 0 )
    {
      if ( status == null)
      {
        status = other.GetComponent<PlayerStatus>();
      }

      if ( status != null )
      {
        status.AdjustHealth( -attackDamage, false );
      }
      alarm = attackTimer;
    }
  }

}
