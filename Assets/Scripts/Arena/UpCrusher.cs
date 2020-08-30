using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpCrusher : MonoBehaviour
{


  public bool ableToUpCrush = false;
  // private float damage = 0f;
  // public float flatDamage = 1000f;
  public float dangerTimer = 0.5f;
  private float alarm = 0f;
  // public float multiplier = 3f;
  // private float maxDamage = 100f;

  public void SetUpCrushable( bool v )
  {
    ableToUpCrush = v;
    alarm = ableToUpCrush ? dangerTimer : 0f;
  }


  private void Update()
  {
    if ( ableToUpCrush )
    {
      alarm -= Time.deltaTime;
      ableToUpCrush = ( alarm > 0 ) ? true : false;
    }
  }

  private void OnTriggerStay( Collider other )
  {
    if ( other.gameObject.tag == "Player" )
    {
      if ( ableToUpCrush )
      {
        other.gameObject.GetComponent<PlayerStatus>().UpCrush( );
        ableToUpCrush = false;
      }
      // Debug.Log( "Taking " + damage + " damage." );
    }
  }

}
