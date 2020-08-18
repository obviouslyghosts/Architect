using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelTriggers : MonoBehaviour
{

  // public GameObject groundFolder;
  public GameObject tower;
  private Renderer ground;
  private Renderer ceiling;
  public bool isTunnelExit;

  private bool isShowingTower;

  private void Start()
  {
    ground = GameObject.Find( "Ground" ).GetComponent<Renderer>();
    ceiling = GameObject.Find( "Ceiling" ).GetComponent<Renderer>();

    tower = GameObject.Find( "Tower" );

    ground.enabled = false;
    ceiling.enabled = false;
  }


  private void OnTriggerEnter( Collider other )
  {
    if ( other.gameObject.tag == "Player" )
    {
      if ( isTunnelExit )
      {
        // just entered the arena
        ground.enabled = true;
        ceiling.enabled = true;

        tower.SetActive( false );
        isShowingTower = false;


      }
      else
      {
        // just entered the tunnel
        ground.enabled = false;
        ceiling.enabled = false;

        tower.SetActive( true );
        isShowingTower = true;
      }

    }
  }

  private void OnTriggerExit(Collider other)
  {
    if ( other.gameObject.tag == "Player" )
    {
      if ( isTunnelExit && isShowingTower )
      {
        ground.enabled = true;
        ceiling.enabled = true;

        tower.SetActive( false );
        isShowingTower = false;

      }
      else if ( !isTunnelExit && !isShowingTower )
      {

        ground.enabled = false;
        ceiling.enabled = false;

        tower.SetActive( true );
        isShowingTower = true;

      }

    }
  }

}
