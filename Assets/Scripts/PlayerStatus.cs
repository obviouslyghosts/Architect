using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
  public float health = 25f;
  public Color colorTransparent;
  public Color colorBlood;
  // private Color colorCurrent;
  public Image damageScreen;
  private bool takingDamage = false;

  public void AdjustHealth( float v )
  {
    health += v;
    if ( v < 0 )
    {
      takingDamage = true;
      damageScreen.color = colorBlood;
    }
  }

  private void Start()
  {
    damageScreen.color = colorTransparent;
  }

  private void Update( )
  {
    if ( takingDamage )
    {
      damageScreen.color = Color.Lerp( damageScreen.color, colorTransparent, 20 * Time.deltaTime);
      if ( damageScreen.color.a <= 0.1 )
      {
        damageScreen.color = colorTransparent;
        takingDamage = false;
      }
    }
  }

}
