using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public static GameController instance;
  public string arena;
  public string title;
  public string death;
  private GameObject playerGun;


  private void Awake()
  {

    if (instance != null)
    {
      Destroy( gameObject );
      return;
    }
    instance = this;
    DontDestroyOnLoad( gameObject );

    SetPlayerMovement( false );
    SetPlayerWeapon( false );
  }

  public void StartArena()
  {
    // enable player movement
    SetPlayerMovement( true );
    // SetPlayerWeapon( true );
    // SceneManager.LoadScene( arena );
  }

  public void StartTitle()
  {
    SceneManager.LoadScene( title );
  }

  public void RestartArena()
  {
    SceneManager.LoadScene( arena );
  }

  public void IsDead()
  {
    SceneManager.LoadScene( death );
  }

  private void SetPlayerMovement( bool v )
  {
    GameObject.Find( "UI-Title" ).SetActive( !v );
    GameObject.Find( "Player" ).GetComponent<PlayerMovement>().SetMovement( v );
    GameObject.Find( "PlayerCamera" ).GetComponent<MouseLook>().SetMovement( v );
    GameObject.Find( "PlayerCamera" ).GetComponent<MouseLook>().LockState( !v );
  }

  public void SetPlayerWeapon( bool v )
  {
    if ( playerGun == null )
    {
      playerGun = GameObject.Find( "PlayerGun" ).gameObject; //SetActive( v );
    }
    playerGun.SetActive( v );
  }


}
