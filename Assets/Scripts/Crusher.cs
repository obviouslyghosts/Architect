using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{

  public bool ableToCrush = false;
  private float damage = 0f;
  public float flatDamage = 1000f;
  public float dangerTimer = 0.5f;
  private float alarm = 0f;
  public float multiplier = 3f;
  private float maxDamage = 100f;

  public void SetCrushable( bool v )
  {
    ableToCrush = v;
    if ( ableToCrush )
    {
      alarm = dangerTimer;
      damage = flatDamage;
    }
    else
    {
      alarm = 0f;
      damage = 0f;
    }
  }


  private void Update()
  {
    if ( ableToCrush )
    {
      alarm -= Time.deltaTime;
      ableToCrush = ( alarm > 0 ) ? true : false;
      // damage = flatDamage;
      // damage += Time.deltaTime * multiplier;
      // ableToCrush = ( damage > maxDamage ) ? false : true;
    }
  }

  private void OnTriggerStay( Collider other )
  {
    if ( other.gameObject.tag == "Player" )
    {
      Debug.Log( "Taking " + damage + " damage." );
      other.gameObject.GetComponent<CharacterController>().enabled = false;
      // other.gameObject.GetComponent<PlayerStatus>().Crushed( true );
      other.gameObject.GetComponent<PlayerStatus>().AdjustHealth( -damage, true );
    }
  }

}
