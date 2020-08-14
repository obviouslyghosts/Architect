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
  public MouseLook mouseLook;
  private bool takingDamage = false;
  private bool dead = false;
  private bool crushed = false;
  public float deathTimer = 1f;
  private float alarm = 0f;
  private GameObject cam;
  private Vector3 camSPos;
  public float crushGround;
  private Vector3 camEPos;
  private float sTime;
  private float journey;
  public float crushSpeed = 4f;
  public bool hasKeyCard = false;

  public void AdjustHealth( float v, bool c )
  {
    if ( health > 0f )
    {
      health += v;
      if ( health <= 0f )
      {
        GetComponent<PlayerMovement>().SetMovement( false );
        dead = true;
        alarm = deathTimer;
      }
      else if ( v < 0 )
      {
        takingDamage = true;
        damageScreen.color = colorBlood;
      }
    }
    if ( !crushed )
    {
      Crushed( c );
    }
  }

  public bool HasKeyCard()
  {
    return hasKeyCard;
  }

  public void Crushed( bool v )
  {
    crushed = v;
    if ( crushed )
    {
      cam = GameObject.Find("PlayerCamera").gameObject;
      camSPos = cam.transform.position;
      camEPos = new Vector3( camSPos.x, crushGround, camSPos.z );
      journey = Vector3.Distance( camSPos, camEPos );
      sTime = Time.time;
    }
  }

  private void Start()
  {
    damageScreen.color = colorTransparent;
    // Game Controller is Singleton
    gameController = GameObject.Find("GameController").GetComponent<GameController>();

  }

  private void Update( )
  {
    if ( alarm > 0 )
    {
      alarm -= Time.deltaTime;
      if ( alarm <= 0 )
      {
        mouseLook.Unlock();

        if ( crushed )
        {
          gameController.Crushed();
        }
        else
        {
          gameController.IsDead();
        }

      }

    }
    if ( takingDamage )
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
    if ( crushed )
    {
      float distCovered = (Time.time - sTime) * crushSpeed;
      float fractionOfJourney = distCovered / journey;
      if ( fractionOfJourney >= 1 )
      {
        // crushed = false;
      }
      else
      {
        cam.transform.position = Vector3.Lerp( camSPos, camEPos, fractionOfJourney);
      }

    }
  }

}
