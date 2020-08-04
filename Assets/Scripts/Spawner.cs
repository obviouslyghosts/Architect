using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

  public GameObject[] enemies;
  public float[] waveTimers;
  private int wave = 0;
  private float alarm = 0f;
  private bool wavesRemaining = true;

  private void Start()
  {
    wavesRemaining = ( waveTimers.Length > 0 );
    if ( wavesRemaining )
    {
      alarm = waveTimers[ wave ];
    }

  }

  private void Update()
  {
    if ( wavesRemaining )
    {

      if ( alarm <= 0 )
      {
        // Wave triggered
        SpawnWave( wave );
        wave ++;
        wavesRemaining = wave < waveTimers.Length;
        alarm = wavesRemaining ? waveTimers[ wave ] : 0;
      }
      else
      {
        alarm -= Time.deltaTime;
      }
    }
  }

  private void SpawnWave( int w )
  {
    Debug.Log( "Triggered Wave" );
    GameObject obj;

    if ( w < enemies.Length )
    {
      obj = enemies[ w ];
    }
    else
    {
      obj = enemies[ UnityEngine.Random.Range( 0, enemies.Length ) ];
    }

    GameObject[] go = GameObject.FindGameObjectsWithTag("Spawn");
    Transform pos = go[ UnityEngine.Random.Range( 0, go.Length ) ].transform;
    Instantiate( obj, pos.position, Quaternion.identity );

  }



}
