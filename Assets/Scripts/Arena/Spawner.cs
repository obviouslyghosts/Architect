using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

  public GameObject[] enemies;
  public GameObject keyCardPrefab;
  private int spawnedEnemies = 0;
  public float[] waveTimers;
  private int wave = 0;
  private float alarm = 0f;
  private float sAlarm = 0f;
  public float spawnTimer = 1f;
  private bool wavesRemaining = true;
  private GameController gameController;
  private AudioManager audioManger;

  private void Start()
  {
    wavesRemaining = ( waveTimers.Length > 0 );
    if ( wavesRemaining )
    {
      alarm = waveTimers[ wave ];
    }
    gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
    audioManger = GameObject.Find( "AudioManager" ).GetComponent<AudioManager>();
  }

  public void ClearRoom()
  {
    GameObject[] enemies = GameObject.FindGameObjectsWithTag( "Enemy" );
    foreach (GameObject e in enemies)
    {
      Destroy( e );
    }
    spawnedEnemies = 0;
    audioManger.EndFight();
    
  }

  public void SpawnRoom()
  {
    sAlarm = spawnTimer;
    audioManger.FightMusic( );
  }

  public void DestroyedEnemy( Vector3 p )
  {
    spawnedEnemies --;
    if ( spawnedEnemies <= 0 )
    {
      ClearRoom( );
      Instantiate( keyCardPrefab, p, Quaternion.identity );
    }
  }


  public void InstantiateRoom()
  {
    int lvl = gameController.GetLevel();
    if ( lvl < 1 )
    {
      lvl = UnityEngine.Random.Range( 1, 99 );
    }

    GameObject[] go = GameObject.FindGameObjectsWithTag("Spawn");
    for ( int n = 0; n < lvl; n++ )
    {
      int u = lvl > enemies.Length ? enemies.Length : lvl;
      int l = ( u - 3 ) < 0 ? 0 : u - 3;

      GameObject obj = enemies[ UnityEngine.Random.Range( l, u ) ];
      Transform pos = go[ UnityEngine.Random.Range( 0, go.Length ) ].transform;
      Instantiate( obj, pos.position, Quaternion.identity );
      spawnedEnemies ++;
    }
  }

  private void Update()
  {
    SpawnTimer( sAlarm );
  }

  private void SpawnTimer( float a )
  {
    if ( a > 0 )
    {
      sAlarm -= Time.deltaTime;
      if ( sAlarm <=0 )
      {
        // triggered
        InstantiateRoom();
      }
    }
  }

  // private void Update()
  // {
  //   // if ( wavesRemaining )
  //   // {
  //   //   if ( alarm <= 0 )
  //   //   {
  //   //     SpawnWave( wave );
  //   //     wave ++;
  //   //     wavesRemaining = wave < waveTimers.Length;
  //   //     alarm = wavesRemaining ? waveTimers[ wave ] : 0;
  //   //   }
  //   //   else
  //   //   {
  //   //     alarm -= Time.deltaTime;
  //   //   }
  //   // }
  // }

  // private void SpawnWave( int w )
  // {
  //   Debug.Log( "Triggered Wave" );
  //   GameObject obj;
  //
  //   if ( w < enemies.Length )
  //   {
  //     obj = enemies[ w ];
  //   }
  //   else
  //   {
  //     obj = enemies[ UnityEngine.Random.Range( 0, enemies.Length ) ];
  //   }
  //
  //   GameObject[] go = GameObject.FindGameObjectsWithTag("Spawn");
  //   Transform pos = go[ UnityEngine.Random.Range( 0, go.Length ) ].transform;
  //   Instantiate( obj, pos.position, Quaternion.identity );
  // }



}
