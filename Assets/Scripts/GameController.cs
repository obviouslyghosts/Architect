using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public static GameController instance;
  public string arena;

  private void Awake()
  {

    if (instance != null)
    {
      Destroy( gameObject );
      return;
    }
    instance = this;
    DontDestroyOnLoad( gameObject );
  }

  public void StartArena()
  {
    SceneManager.LoadScene( arena );    
  }


}
