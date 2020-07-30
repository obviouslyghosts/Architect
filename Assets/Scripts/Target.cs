using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
  public float health = 50f;
  public bool isPillar = false;
  public Rigidbody hex;
  public GameObject pillar;
  public Crusher crusher;

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
      if ( crusher != null )
      {
        crusher.SetCrushable( true );
      }
      Destroy( gameObject.GetComponent<MeshCollider>() );
      Destroy( pillar );
    }
    else
    {
      Destroy( gameObject );
    }

  }
}
