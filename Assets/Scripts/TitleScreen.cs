using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{

  private void Start()
  {
    GameController gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
    gameController.SetPlayerMovement( false );
    gameController.SetPlayerWeapon( false );
    gameController.SetMouseVisibility( true );
  }
}
