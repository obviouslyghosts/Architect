using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
  public Animator wallAnimator;
  public MeshCollider hexCollision;
  private float timer = 0f;
  private float alarm = 1f;

  private bool isPrimed = false;

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
      // Debug.Log("Crushing");
      wallAnimator.SetTrigger( "Crush" );
      // crusher.SetCrushable( true );
      isPrimed = false;
    }
  }

  public void Prime( bool v )
  {
    if ( !isPrimed && v )
    {
      // check children for pillar
      // if ( transform.childCount <= 1 )
      // {
      //   GameObject p = Instantiate( pillarPrefab, transform.position, Quaternion.identity );
      //   p.transform.parent = gameObject.transform;
      // }
      // hexCollision.enabled = true;
      wallAnimator.SetTrigger( "Prime" );
      isPrimed = true;
      // interactable.SetActive( true );
    }
  }

  // public void Chase()
  // {
  //   if ( transform.childCount <= 1 )
  //   {
  //     GameObject p = Instantiate( pillarPrefab, transform.position, Quaternion.identity );
  //     p.transform.parent = gameObject.transform;
  //   }
  //
  //   wallAnimator.SetTrigger( "Chase" );
  //   isPrimed = true;
  // }

}
