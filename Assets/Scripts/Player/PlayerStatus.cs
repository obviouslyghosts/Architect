using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
  public float health = 25f;
  public Color colorTransparent;
  public Color colorBlood;
  public Color colorDeath;
  // private Color colorCurrent;
  public Image damageScreen;
  public GameController gameController;
  public ArenaController arenaController;
  // public GameObject playerCamera;
  public GameObject fluidPrefab;
  public GameObject crushPrefab;
  public GameObject upCrushPrefab;
  

  public GameObject ground;
  public GameObject ceiling;
  public MouseLook mouseLook;
  private bool takingDamage = false;
  private bool dead = false;
  private bool crushed = false;
  public float deathTimer = 1f;
  public float textTimer = 2f;
  private float alarm = 0f;
  private float tAlarm = 0f;
  private GameObject cam;
  private float camY;
  private Vector3 camSPos;
  public float crushGround;
  private Vector3 camEPos;
  private float sTime;
  private float journey;
  public float camTransSpeed = 4f;
  public bool hasKeyCard = false;
  private bool cameraTransition = false;
  private bool cameraFallThrough = false;
  private Vector2 crushDirection = Vector2.zero;
  public AnimationCurve downCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
  public AnimationCurve upCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
  private bool inTunnel = false;

  public void AdjustHealth( float v, bool c )
  {
    if ( health > 0f )
    {
      health += v;
      if ( health <= 0f )
      {
        // Dead()
        GetComponent<PlayerMovement>().SetMovement( false );
        dead = true;
        alarm = deathTimer;
      }
      else if ( v < 0 )
      {
        // Damaged()
        takingDamage = true;
        damageScreen.color = colorBlood;
      }
    }
    if ( !crushed )
    {
      Crushed( c );
    }
  }

  public void InTunnel( bool v )
  {
    inTunnel = v;
  }

  public bool TunnelCheck()
  {
    return inTunnel | hasKeyCard;
  }

  public void DownCrush()
  {
    Debug.Log("DOWNCRUSHER");
    Crush( Vector2.down );
    // gameObject.GetComponent<CharacterController>().enabled = false;
    // crushDirection = Vector2.down;
    // camSPos = cam.transform.position;
    // camEPos = SetPos( false, crushDirection, camSPos);
    // SetupTransition( );
    // cameraFallThrough = true;
    // Splatter( camSPos );
  }

  public void UpCrush()
  {
    Debug.Log("UPCRUSHER");
    Crush( Vector2.up );

    // gameObject.GetComponent<CharacterController>().enabled = false;
    // crushDirection = Vector2.up;
    // camSPos = cam.transform.position;
    // camEPos = SetPos( false, crushDirection, camSPos);
    // SetupTransition( );
    // cameraFallThrough = true;
    // Splatter( camSPos );
  }

  private void Crush( Vector2 d)
  {
    gameObject.GetComponent<CharacterController>().enabled = false;
    crushDirection = d;
    camSPos = cam.transform.position;
    camEPos = SetPos( false, crushDirection, camSPos);
    SetupTransition( );
    cameraFallThrough = true;
    Splatter( camSPos );
  }

  private Vector3 SetPos( bool fallThrough, Vector2 direction, Vector3 camPos )
  {
    // if fallthrough, reverse direction
    float y = 0f;

    direction = fallThrough ? direction * Vector2.down : direction;

    y = direction == Vector2.down ? ground.transform.position.y : y;
    y = direction == Vector2.up ? ceiling.transform.position.y : y;

    return new Vector3( camPos.x, y, camPos.z );
  }

  private void SetupTransition()
  {
    cameraTransition = true;
    journey = Vector3.Distance( camSPos, camEPos );
    sTime = Time.time;
  }

  public bool HasKeyCard()
  {
    return hasKeyCard;
  }

  public void PickupKeyCard( bool v )
  {
    arenaController.OpenRandomWall();
    hasKeyCard = v;
  }

  public void Crushed( bool v )
  {
    crushed = v;
    if ( crushed )
    {
      // cam = GameObject.Find("PlayerCamera").gameObject;
      camSPos = cam.transform.position;
      camEPos = new Vector3( camSPos.x, crushGround, camSPos.z );
      journey = Vector3.Distance( camSPos, camEPos );
      sTime = Time.time;
    }
  }

  private void Start()
  {
    cam = GameObject.Find("PlayerCamera").gameObject;
    damageScreen.color = colorTransparent;
    // Game Controller is Singleton
    gameController = GameObject.Find("GameController").GetComponent<GameController>();
    gameController.ShowLevelText( true, 0 );
    tAlarm = textTimer;
    camY = cam.transform.position.y;
  }

  private void Update( )
  {
    TextTimer( tAlarm );
    DeathTimer( alarm );
    TakingDamage( takingDamage, dead );
    CamTransition( cameraTransition );
  }

  private void DeathTimer( float a )
  {
    if ( a > 0 )
    {
      alarm -= Time.deltaTime;
      if ( alarm <= 0 )
      {
        mouseLook.Unlock();
        gameController.IsDead();
      }
    }
  }

  private void TextTimer( float a )
  {
    if ( a > 0 )
    {
      tAlarm -= Time.deltaTime;
      if ( tAlarm <= 0 )
      {
        gameController.ShowLevelText( false, 0 );
      }
    }
  }

  private void TakingDamage( bool dmg, bool dead )
  {
    if ( dmg )
    {
      damageScreen.color = Color.Lerp( damageScreen.color, colorTransparent, 5 * Time.deltaTime);
      if ( damageScreen.color.a <= 0.1 )
      {
        damageScreen.color = colorTransparent;
        takingDamage = false;
      }
    }
    else if ( dead )
    {
      damageScreen.color = Color.Lerp( damageScreen.color, colorDeath, 5 * Time.deltaTime);
      if ( damageScreen.color.a >= 0.9 )
      {
        damageScreen.color = colorDeath;
        dead = false;
      }
    }
  }

  private void Splatter( Vector3 pos )
  {
    if ( crushDirection == Vector2.down )
    {
      // Instantiate( fluidPrefab, pos, Quaternion.identity );
      GameObject fp = Instantiate( fluidPrefab, pos, Quaternion.identity );
      fp.transform.parent = cam.transform;
      fp.transform.localPosition += new Vector3( 0, -0.20f, 1.2f);
      fp.transform.parent = null;
      Destroy( fp, 1.5f );
    }
    else
    {
      GameObject fp = Instantiate( upCrushPrefab, pos, Quaternion.identity );
      fp.transform.parent = cam.transform;
      fp.transform.localPosition += new Vector3( 0, -0.20f, 1.2f);
      fp.transform.parent = null;
      Destroy( fp, 1.5f );
    }
  }

  private void Crush( Vector3 pos )
  {
    GameObject fp = Instantiate( fluidPrefab, pos, Quaternion.identity );
    fp.transform.parent = cam.transform;
    fp.transform.localPosition += new Vector3( 0, -0.20f, 1.2f);
    fp.transform.parent = null;
    Destroy( fp, 1.5f );
  }

  private void CamTransition( bool v )
  {
    if ( v )
    {
      float distCovered = (Time.time - sTime) * camTransSpeed;
      float fractionOfJourney = distCovered / journey;
      if ( fractionOfJourney >= 1 )
      {
        if ( cameraFallThrough )
        {
          gameController.ShowLevelText( true, (int)crushDirection.y );
          arenaController.ResetHexes( true );
          arenaController.ClearRoom();
          arenaController.SpawnRoom();

          // arenaController
          tAlarm = textTimer;

          cam.transform.position = SetPos( true, crushDirection, camSPos);
          camEPos = new Vector3( camSPos.x, camSPos.y, camSPos.z );
          camSPos = cam.transform.position;
          SetupTransition();
          Splatter( camSPos );
          cameraFallThrough = false;
        }
        else
        {
          gameObject.GetComponent<CharacterController>().enabled = true;
          cameraTransition = false;
          return;
        }
      }

      AnimationCurve c = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

      c = crushDirection == Vector2.up ? upCurve : c;
      c = crushDirection == Vector2.up ? downCurve : c;

      cam.transform.position = Vector3.Lerp( camSPos, camEPos, c.Evaluate( fractionOfJourney ) );
      }

    }

}
