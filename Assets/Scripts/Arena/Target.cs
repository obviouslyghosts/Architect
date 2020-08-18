using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
  public bool isPillar = false;
  public float health = 50f;
  public GameObject destroyedVersion;
  // private float actualHealth = 0f;

  public void TakeDamage( float d )
  {
    health -= d;
    if ( health <= 0f )
    {
      // dead
      if ( isPillar )
      {
        transform.parent.gameObject.GetComponent<CrushController>().Crush( true );
      }
      Instantiate(destroyedVersion, transform.position, transform.rotation );
      Destroy( gameObject );
    }

  }



}
