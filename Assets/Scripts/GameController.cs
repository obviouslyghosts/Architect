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
  public GameObject tower;
  // private Transform playerTrans;
  private Vector3 playerPos;
  private Quaternion playerRot;
  private bool upCrush = false;
  private bool downCrush = false;
  private bool enableCC = false;

  public bool isShowingTower = true;


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
    if ( GameObject.Find( "Tower") != null )
    {
      tower = GameObject.Find( "Tower" ).gameObject;
    }
  }


  public void StartArena()
  {
    // enable player movement
    SetPlayerMovement( true );
    SetMouseVisibility( false );
    // ShowLevelText( true, 0 );
  }

  public bool IsShowingTower()
  {
    return isShowingTower;
  }

  public void ShowTower( bool v )
  {
    tower.SetActive( v );
    isShowingTower = v;
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
