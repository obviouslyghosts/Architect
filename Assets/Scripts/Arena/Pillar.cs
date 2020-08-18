using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
  public float health = 50f;
  public Rigidbody hex;

  public void TakeDamage( float amount )
  {
    health -= amount;
    if ( health <=0 )
    {
      Die();
    }

  }

  private void Die()
  {
    hex.isKinematic = false;
    Destroy( gameObject );
  }
}
