using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

  public GameObject interactText;
  private bool interacting;
  private GameObject interactingObj;

  private void Start()
  {
    if ( interactText == null )
    {
      interactText = GameObject.Find( "InteractText" ).gameObject;
    }
    interactText.SetActive( false );
  }

  private void Update()
  {
    if ( interacting && Input.GetAxis( "Interact" ) > 0 )
    {
      if ( interactingObj != null )
      {
        Interact( interactingObj.GetComponent<Interaction>().GetInteraction() );
      }
    }

  }

  private void Interact( string interactionType )
  {
    switch ( interactionType )
    {
      case "Pickup":
        Destroy( interactingObj.transform.parent.gameObject );
        GameObject.Find( "GameController" ).GetComponent<GameController>().SetPlayerWeapon( true );
        break;
      default:
        break;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if ( other.gameObject.tag == "Interact" )
    {
      interactText.SetActive( true );
      interacting = true;
      interactingObj = other.gameObject;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if ( other.gameObject.tag == "Interact" )
    {
      interactText.SetActive( false );
      interacting = false;
      interactingObj = null;
    }
  }

}
