using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{

  public Animator gateAnimator;
  public MeshCollider gateCollision;
  public GameObject interact;

  private bool isOpen = true;

  private void Start()
  {
    isOpen = true;
    interact.SetActive( false );
  }

  public void Interact( bool v )
  {
    if ( !isOpen & v )
    {
      OpenGate();
    }
  }

  public void OpenGate()
  {
    isOpen = true;
    gateCollision.enabled = false;
    gateAnimator.SetTrigger( "Open" );
    interact.SetActive( false );
  }

  public void CloseGate()
  {
    isOpen = false;
    gateCollision.enabled = true;
    gateAnimator.SetTrigger( "Close" );
    interact.SetActive( true );
  }

  // private void OnTriggerEnter( Collider other )
  // {
  //   if ( other.gameObject.tag == "Interact" )
  //   {
  //     interactText.SetActive( true );
  //     interacting = true;
  //     interactingObj = other.gameObject;
  //   }
  // }
  //
  // private void OnTriggerExit(Collider other)
  // {
  //   if ( other.gameObject.tag == "Interact" )
  //   {
  //     interactText.SetActive( false );
  //     interacting = false;
  //     interactingObj = null;
  //   }
  // }

}
