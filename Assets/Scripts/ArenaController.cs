using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
  public GameObject tunnelPrefab;
  public GameObject player;
  public Transform center;
  private ArenaMaker arenaMaker;

  private GameObject wall;



  private void Start()
  {
    arenaMaker = GetComponent<ArenaMaker>();
    arenaMaker.DrawArena();
    EnterThroughTunnel( resetHex:false );
  }

  public void EnterThroughTunnel( bool resetHex )
  {
    // Start Arena in tunnel
    // Draw Blood On Screen
    Debug.Log( "tunnel stuff" );
    if ( resetHex )
    {
      ResetArenaHex();
    }

    GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
    wall = walls[ UnityEngine.Random.Range(0, walls.Length ) ];
    wall.transform.SetParent( null );
    Vector3 pos = wall.transform.position;
    wall.SetActive( false );
    GameObject t = Instantiate( tunnelPrefab, pos, Quaternion.identity );
    t.transform.LookAt( center );

    player.GetComponent<CharacterController>().enabled = false;
    // charController.enabled = false;
    player.transform.position = t.GetComponent<TunnelController>().GetPlayerSpawn();
    // charController.enabled = true;
    player.GetComponent<CharacterController>().enabled = true;
    
    // Debug.Log( player.transform.position );

    // Get 1 Wall, remember it, and Disable it
    // draw tunnel at that point
    // Get rotation (60 degrees...)
    // put player at tunnel start location
  }

  public void EnterThroughRoof()
  {
    // resent cordinates

  }

  public void ResetArenaHex()
  {
    // all Hexes are resent to UP
    GameObject[] hexes;

    hexes = GameObject.FindGameObjectsWithTag("Hex");

    foreach (GameObject h in hexes)
    {
      h.GetComponent<Target>().Reset();
    }

  }

  public void DrawEntrance()
  {
    // make tunnel
  }


}
