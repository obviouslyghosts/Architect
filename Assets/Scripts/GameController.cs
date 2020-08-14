using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  // public string titleScene;
  public static GameController instance;
  public string arena;
  public string title;
  public string death;
  public string test;

  private GameObject playerGun;
  private Vector3 playerPos;

  private void Awake()
  {

    if (instance != null)
    {
      Destroy( gameObject );
      return;
    }
    instance = this;
    DontDestroyOnLoad( gameObject );
    SetMouseVisibility( false );

  }

  public void StartArena()
  {
    // enable player movement
    SetPlayerMovement( true );
    SetMouseVisibility( false );

  }

  public void StartTitle()
  {
    SceneManager.LoadScene( title );
  }

  public void RestartArena()
  {
    SceneManager.LoadScene( arena );
  }

  public void Crushed()
  {
    Debug.Log( "Crushed" );

    SceneManager.LoadScene( SceneManager.GetActiveScene().name );
  }

  public void IsDead()
  {
    SceneManager.LoadScene( death );
  }

  public void SetPlayerMovement( bool v )
  {
    GameObject.Find( "UI-Title" ).SetActive( !v );
    GameObject.Find( "Player" ).GetComponent<PlayerMovement>().SetMovement( v );
    GameObject.Find( "PlayerCamera" ).GetComponent<MouseLook>().SetMovement( v );
  }

  public void SetMouseVisibility( bool v )
  {
    GameObject.Find( "PlayerCamera" ).GetComponent<MouseLook>().LockState( v );
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
