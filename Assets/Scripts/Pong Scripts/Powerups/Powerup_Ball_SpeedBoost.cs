using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Ball_SpeedBoost : MonoBehaviour
{

    public float multiplier = 3.0f;
    public float duration = 3.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            StartCoroutine (Pickup(collision));
        }

        IEnumerator Pickup(Collider2D ball)
        {
            Debug.Log("Powerup Picked Up");

           Ball Ballspeed = ball.GetComponent<Ball>();
           Ballspeed.speed *= multiplier;

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            yield return new WaitForSeconds(duration);
           Ballspeed.speed /= multiplier;

            Destroy(gameObject);
        }
    }
}
