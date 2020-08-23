using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTextController : MonoBehaviour
{
  public float timer = 2f;
  private float alarm = 0f;

  // private void Awake()
  // {
  //   Debug.Log( "SHOWING LEVEL TEXT" );
  //   alarm = timer;
  // }

  private void Update()
  {
    if ( alarm <= 0f )
    {
      gameObject.SetActive( false );
    }

    alarm -= Time.deltaTime;
  }

}
