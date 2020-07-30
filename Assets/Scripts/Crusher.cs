using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{

  public bool ableToCrush = false;
  private float damage = 0f;
  public float multiplier = 3f;
  private float maxDamage = 100f;

  public void SetCrushable( bool v )
  {
    ableToCrush = v;
  }


  private void Update()
  {
    if ( ableToCrush )
    {
      damage += Time.deltaTime * multiplier;
      ableToCrush = ( damage > maxDamage ) ? false : true;
    }
  }

  private void OnCollisionStay( Collision other )
  {
    if ( other.gameObject.tag == "Player" )
    {
      Debug.Log( "Taking " + damage + " damage." );
      other.gameObject.GetComponent<PlayerStatus>().AdjustHealth( -damage );
    }
  }

}
