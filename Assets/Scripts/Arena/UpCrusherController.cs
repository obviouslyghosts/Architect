using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpCrusherController : MonoBehaviour
{
  public Animator hexAnimator;
  // public MeshCollider hexCollision;
  public UpCrusher upCrusher;

  private float timer = 0f;
  private float alarm = 1f;

  private bool isPrimed = true;

  private void Update()
  {
    if ( timer > 0f )
    {
      timer -= Time.deltaTime;
    }
  }


  public void Trigger()
  {
    if ( timer <= 0f )
    {
      if ( isPrimed )
      {
        Crush( true );
        timer = alarm;
      }
      else
      {
        Prime( true );
        timer = alarm;

      }
    }
  }

  public void Crush( bool v )
  {
    if ( isPrimed && v )
    {
      Debug.Log("Up Crushing!");
      hexAnimator.SetTrigger( "Crush" );
      upCrusher.SetUpCrushable( true );

      isPrimed = false;
    }
  }

  public void Prime( bool v )
  {
    if ( !isPrimed && v )
    {
      hexAnimator.SetTrigger( "Prime" );
      isPrimed = true;
    }
  }

  public void Chase()
  {
    hexAnimator.SetTrigger( "Chase" );
    isPrimed = true;
  }

}
