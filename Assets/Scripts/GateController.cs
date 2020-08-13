using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{

  public Animator gateAnimator;
  public MeshCollider gateCollision;
  public GameObject interactable;

  private bool isOpen = false;

  public void OpenGate( bool v )
  {
    if ( !isOpen && v )
    {
      isOpen = true;
      gateCollision.enabled = false;
      gateAnimator.SetTrigger( "Open" );
      interactable.SetActive( false );
    }
  }

  public void CloseGate( bool v )
  {
    if ( isOpen && v )
    {
      isOpen = false;
      gateCollision.enabled = true;
      gateAnimator.SetTrigger( "Close" );
      interactable.SetActive( true );
    }
  }
}
