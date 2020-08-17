using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
  // public string titleScene;
  public static GameController instance;
  public string arena;
  public string title;
  public string death;
  public string test;
  public int level = 1;
  public GameObject levelText;

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

  public void StartArena()
  {
    // enable player movement
    SetPlayerMovement( true );
    SetMouseVisibility( false );
    // ShowLevelText( true, 0 );
  }

  public void StartTitle()
  {
    SceneManager.LoadScene( title );
  }

  public void RestartArena()
  {
    SceneManager.LoadScene( arena );
  }

  public int GetLevel()
  {
    return level;
  }

  public void ShowLevelText( bool v, int i )
  {
    levelText.SetActive( v );
    Debug.Log( i );
    level += i;
    if ( v )
    {
      Text t = levelText.GetComponent<Text>();
      if ( t != null )
      {
        t.text = "LEVEL " + level;
      }
    }
  }

  // public void Crushed()
  // {
  //   Debug.Log( "Crushed" );
  //   GameObject player = GameObject.Find( "Player" ).gameObject;
  //   playerPos = player.transform.position;
  //   playerRot = player.transform.rotation;
  //   // playerTrans = GameObject.Find( "Player" ).gameObject.transform;
  //   downCrush = true;
  //   // re load the same scene
  //   SceneManager.LoadScene( SceneManager.GetActiveScene().name );
  // }

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
