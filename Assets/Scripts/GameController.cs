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
  // private Transform playerTrans;
  private Vector3 playerPos;
  private Quaternion playerRot;
  private bool upCrush = false;
  private bool downCrush = false;
  private bool enableCC = false;

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

  // private void Update()
  // {
  //   // how is this being started!!
  //   if ( upCrush | downCrush )
  //   {
  //     Debug.Log("CRUSH START");
  //     GameObject player = GameObject.Find( "Player" ).gameObject;
  //
  //     player.GetComponent<CharacterController>().enabled = false;
  //     player.transform.position = new Vector3( playerPos.x, playerPos.y, playerPos.z );
  //     player.transform.rotation = playerRot;
  //     // FallThrough();
  //     enableCC = true;
  //
  //     upCrush = false;
  //     downCrush = false;
  //   }
  //
  //   if ( enableCC )
  //   {
  //     GameObject.Find( "Player" ).gameObject.GetComponent<CharacterController>().enabled = true;
  //     enableCC = false;
  //   }
  //
  // }

  public void ResetHexes()
  {
    // move to arena
    GameObject[] hexes;
    hexes = GameObject.FindGameObjectsWithTag("Hex");
    foreach (GameObject h in hexes)
    {
      h.GetComponent<CrushController>().Chase();
      // h.GetComponent<Target>().Reset();
    }

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
    GameObject player = GameObject.Find( "Player" ).gameObject;
    playerPos = player.transform.position;
    playerRot = player.transform.rotation;
    // playerTrans = GameObject.Find( "Player" ).gameObject.transform;
    downCrush = true;
    // re load the same scene
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
