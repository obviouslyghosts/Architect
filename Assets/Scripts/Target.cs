using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
  public float health = 50f;
  private float actualHealth = 0f;
  public bool isPillar = false;
  private bool triggered = false;
  public GameObject hex;
  private Vector3 originalPos;
  private Rigidbody hexRB;

  public GameObject pillar;
  public Crusher crusher;

  private void Start()
  {
    actualHealth = health;
    hexRB = hex.GetComponent<Rigidbody>();
    originalPos = hex.transform.position;
  }

  public void TakeDamage( float amount )
  {
    actualHealth -= amount;
    if ( actualHealth <= 0 )
    {
      Die();
    }

  }

  public void Reset( )
  {
    actualHealth = health;
    if ( triggered )
    {
      triggered = false;

      if ( isPillar )
      {
        hexRB.isKinematic = true;
        hex.transform.position = originalPos;
        SetPillar( true );
      }

    }

  }

  private void Die()
  {
    triggered = true;
    if ( isPillar )
    {
      hexRB.isKinematic = false;
      if ( crusher != null )
      {
        crusher.SetCrushable( true );
      }
      SetPillar( false );
      // Destroy( gameObject.GetComponent<MeshCollider>() );
      // Destroy( pillar );
    }
    else
    {
      Destroy( gameObject );
    }
  }

  private void SetPillar( bool v )
  {
    gameObject.GetComponent<MeshCollider>().enabled = v;
    pillar.SetActive( v );
  }
}
