using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelTriggers : MonoBehaviour
{

  // public GameObject groundFolder;
  // public GameObject tower;
  private GameController gameController;
  private Renderer ground;
  private Renderer ceiling;
  public bool isTunnelExit;

  // private bool isShowingTower;

  private void Start()
  {
    gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
    ground = GameObject.Find( "Ground" ).GetComponent<Renderer>();
    ceiling = GameObject.Find( "Ceiling" ).GetComponent<Renderer>();

    // tower = GameObject.Find( "Tower" );

    // ground.enabled = !gameController.IsShowingTower();
    // ceiling.enabled = !gameController.IsShowingTower();
  }


  private void OnTriggerEnter( Collider other )
  {
    if ( other.gameObject.tag == "Player" )
    {
      UpdateVisibility( !isTunnelExit );
    }
  }


  private void OnTriggerExit(Collider other)
  {
    if ( other.gameObject.tag == "Player" )
    {
      UpdateVisibility( !isTunnelExit );
    }
  }

  private void UpdateVisibility( bool s )
  {
    gameController.ShowTower( s );
    ground.enabled = !s;
    ceiling.enabled = !s;

    // tower.SetActive( s );
  }

}
