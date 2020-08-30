using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShut : MonoBehaviour
{

  public bool isInsideTunnel = false;


  private void OnTriggerEnter(Collider other)
  {
    if ( other.gameObject.tag == "Player" )
    {
      if ( isInsideTunnel )
      {
        other.gameObject.GetComponent<PlayerStatus>().InTunnel( true );
      }

    }
  }


  private void OnTriggerExit(Collider other)
  {
    if ( other.gameObject.tag == "Player" )
    {
      if ( isInsideTunnel )
      {
        other.gameObject.GetComponent<PlayerStatus>().InTunnel( false );
      }
      else
      {
        bool tunnelCheck = other.gameObject.GetComponent<PlayerStatus>().TunnelCheck( );
        GameObject.Find( "Arena" ).GetComponent<ArenaController>().LeavingTunnel( !tunnelCheck );
      }
    }
  }

}
