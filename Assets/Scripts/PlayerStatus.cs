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
  public float deathTimer = 1f;
  private float alarm = 0f;

  public void AdjustHealth( float v )
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
        gameController.IsDead();
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
      damageScreen.color = Color.Lerp( damageScreen.color, colorDeath, 20 * Time.deltaTime);
      if ( damageScreen.color.a >= 0.9 )
      {
        damageScreen.color = colorDeath;
        dead = false;
      }
    }
  }

}
