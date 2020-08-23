using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenes : MonoBehaviour
{
  private GameController gameController;

  private void Start()
  {
    gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
  }

  public void TitleScreenMovement()
  {
    gameController.LetPlayerMove();
  }

  public void StartArena()
  {
    gameController.SetLevel( 1 );
    gameController.StartArena();
  }

  public void StartTitle()
  {
    gameController.StartTitle();
  }



}
