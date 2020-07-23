using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
  public float health = 50f;
  public bool isPillar = false;
  public Rigidbody hex;
  public GameObject pillar;

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
    if ( isPillar )
    {
      hex.isKinematic = false;
      Destroy( gameObject.GetComponent<MeshCollider>() );
      Destroy( pillar );
    }
    else
    {
      Destroy( gameObject );
    }

  }
}
