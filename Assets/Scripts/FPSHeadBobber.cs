using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From MoArtis

public class FPSHeadBobber : MonoBehaviour
{
    [SerializeField] float bobbingSpeed = 0.2f;
    [SerializeField] Vector2 bobbingAmount = new Vector2(0.5f, 0.5f);
    [SerializeField] Vector2 startPoints = new Vector2(0.0f, 0.0f);

    private float timer = 0.0f;

    [SerializeField] CharacterController charController;
    [SerializeField] Transform camTransform;

    // Update is called once per frame
    void Update()
    {
        Vector2 waveslices = Vector2.zero;
        Vector3 velocity3d = charController.velocity;
        Vector2 velocity = new Vector2(velocity3d.x, velocity3d.z);

        //Is it stopped? SqrMagnitude is enough as we are just comparing values.
        //Epsilon is a number very close to 0.
        if (velocity.sqrMagnitude <= Mathf.Epsilon)
        {
            timer = 0.0f;
        }
        else
        {
            waveslices.x = Mathf.Sin(timer * 0.5f);
            waveslices.y = (Mathf.Cos(timer + Mathf.PI) + 1f) / 2f;
            timer += bobbingSpeed;
        }

        Vector2 translateChange = waveslices * bobbingAmount;
        camTransform.localPosition = startPoints + translateChange;
    }
}
