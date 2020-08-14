using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
  public Vector2 timerRange;
  private float timer;

  private void Start()
  {
    timer = UnityEngine.Random.Range( timerRange.x, timerRange.y );
  }

  private void Update( )
  {
    if ( timer <= 0 )
    {
      Destroy( gameObject );
    }

    timer -= Time.deltaTime;

  }


}
