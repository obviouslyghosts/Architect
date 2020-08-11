using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

  public GameObject interactText;
  private bool interacting;
  private GameObject interactingObj;
  public float startTimer = 1f;
  // private float timer = 0f;
  private float alarm = -1f;
  private string timerAction = "";

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

    if ( alarm > 0f )
    {
      alarm -= Time.deltaTime;
      if ( alarm <= 0f )
      {
        alarm = -1;
        TimerTrigger( timerAction );
        // triggered
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
        alarm = startTimer;
        timerAction = "Start";
        break;
      default:
        break;
    }
  }

  private void TimerTrigger( string timerType )
  {
    switch ( timerType )
    {
      case "Start":
        // Destroy( interactingObj.transform.parent.gameObject );
        GameObject.Find( "GameController" ).GetComponent<GameController>().RestartArena( );
        break;
      default:
        break;
    }
  }

  private void OnTriggerEnter( Collider other )
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
