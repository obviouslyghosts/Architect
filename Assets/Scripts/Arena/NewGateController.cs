using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGateController : MonoBehaviour
{
  // private PlayerStatus playerStatus;
  public Animator gateAnimator;
  public MeshCollider gateCollision;
  public GameObject interactable;
  private bool isOpen = true;


  private void Interact( bool v )
  {
    if ( !isOpen & v )
    {
      OpenGate();
    }

  }

  public void OpenGate( )
  {
    isOpen = true;
    gateCollision.enabled = false;
    gateAnimator.SetTrigger( "Open" );
    interactable.SetActive( false );
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
