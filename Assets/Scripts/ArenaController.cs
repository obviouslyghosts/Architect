using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
  public GameObject tunnelPrefab;
  public GameObject player;
  public Transform center;
  private ArenaMaker arenaMaker;
  private ArenaMaterials arenaMaterials;
  private Spawner spawner;

  private GameObject wall;



  private void Start()
  {
    arenaMaker = GetComponent<ArenaMaker>();
    arenaMaterials = GetComponent<ArenaMaterials>();
    spawner = GetComponent<Spawner>();
    arenaMaker.DrawArena( );
    ResetMaterials( );
    EnterThroughTunnel( );
    SpawnRoom();
  }

  public void EnterThroughTunnel( )
  {

    GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
    wall = walls[ UnityEngine.Random.Range(0, walls.Length ) ];
    wall.transform.SetParent( null );
    Vector3 pos = wall.transform.position;
    wall.SetActive( false );
    GameObject t = Instantiate( tunnelPrefab, pos, Quaternion.identity );
    t.transform.LookAt( center );

    player.GetComponent<CharacterController>().enabled = false;
    player.transform.position = t.GetComponent<TunnelController>().GetPlayerSpawn();
    player.transform.LookAt( center );

    player.GetComponent<CharacterController>().enabled = true;
  }

  public void ResetMaterials( )
  {
    int lvl = GameObject.Find( "GameController" ).GetComponent<GameController>().GetLevel();
    Debug.Log( "Resetting Materials to index "+ lvl );
    GameObject[] objs;


    // HEXES
    objs = GameObject.FindGameObjectsWithTag( "Hex-Mesh" );
    Material m = arenaMaterials.GetMat( "HEXFACE", lvl );
    Material n = arenaMaterials.GetMat( "HEXWALL", lvl );
    foreach (GameObject h in objs)
    {
      Material[] mats = h.GetComponent<Renderer>().materials;
      mats[0] = n;
      mats[1] = m;
      h.GetComponent<Renderer>().materials = mats;
    }

    // WALLS
    objs = GameObject.FindGameObjectsWithTag( "Wall-Mesh" );
    m = arenaMaterials.GetMat( "WALL", lvl );
    Debug.Log( m );
    Debug.Log( "Number of Walls: " + objs.Length );
    foreach (GameObject h in objs)
    {
      Material[] mats = h.GetComponent<Renderer>().materials;
      mats[1] = m;
      h.GetComponent<Renderer>().materials = mats;
      // mats[1] = n;
      // h.GetComponent<MeshRenderer>().materials[0] = m;
    }

    // GRATE
    objs = GameObject.FindGameObjectsWithTag( "Ground" );
    m = arenaMaterials.GetMat( "GRATE", lvl );
    foreach (GameObject h in objs)
    {
      Material[] mats = h.GetComponent<Renderer>().materials;
      mats[0] = m;
      h.GetComponent<Renderer>().materials = mats;

      // h.GetComponent<Renderer>().materials[0] = m;
    }
  }



  public void ResetHexes( bool v )
  {
    GameObject[] hexes;
    hexes = GameObject.FindGameObjectsWithTag("Hex");
    foreach (GameObject h in hexes)
    {
      h.GetComponent<CrushController>().Chase();
    }

    if ( v )
    {
      ResetMaterials();
    }
  }

  public void DestroyedEnemy( Vector3 p )
  {
    spawner.DestroyedEnemy( p );
  }

  public void SpawnRoom()
  {
    spawner.SpawnRoom();
  }

  public void ClearRoom()
  {
    spawner.ClearRoom();
  }


}
