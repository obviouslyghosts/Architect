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
  private string sceneName;
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
    sceneName = SceneManager.GetActiveScene().name;
    DontDestroyOnLoad( gameObject );
    SetMouseVisibility( false );
    // CustomLoad();
  }

  public void CustomLoad( string s )
  {
    // string s = SceneManager.GetActiveScene().name;
    sceneName = ( sceneName != s ) ? s : sceneName;

    if ( sceneName == title )
    {
      SetPlayerMovement( false );
      SetPlayerWeapon( false );
      SetMouseVisibility( true );
    }

    if ( sceneName == arena )
    {
      levelText = GameObject.Find( "LevelText" ).gameObject;
      tower = GameObject.Find( "Tower" ).gameObject;
    }

    if ( sceneName == death )
    {

    }
    if ( sceneName == test )
    {

    }

  }


  public void LetPlayerMove()
  {
    // enable player movement
    SetPlayerMovement( true );
    SetMouseVisibility( false );
  }

  public bool IsShowingTower()
  {
    return isShowingTower;
  }

  public void ShowTower( bool v )
  {
    if ( tower == null )
    {
      tower = GameObject.Find( "Tower" ).gameObject;
    }
    if ( tower != null )
    {
      tower.SetActive( v );
      isShowingTower = v;
    }
  }

  public void StartTitle()
  {
    SceneManager.LoadScene( title );
  }

  public void StartArena()
  {
    SceneManager.LoadScene( arena );
    // scene = SceneManager.GetActiveScene();

  }

  public int GetLevel()
  {
    return level;
  }

  public void ShowLevelText( bool v, int i )
  {
    // check scene
    if ( SceneManager.GetActiveScene().name == arena )
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
