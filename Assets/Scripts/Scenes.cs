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

  public void StartArena()
  {
    gameController.StartArena();
  }

  public void Restart()
  {
    gameController.RestartArena();
  }

  public void StartTitle()
  {
    gameController.StartTitle();
  }



}
