using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Ball_SizeIncrease : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 3.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag ("Ball"))
        {
            StartCoroutine( Pickup(collision));
        }    

        IEnumerator Pickup(Collider2D ball)
        {
            Debug.Log("Powerup Picked Up");

            ball.transform.localScale *= multiplier;

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            yield return new WaitForSeconds(duration);
            ball.transform.localScale /= multiplier;

            Destroy(gameObject);
        }
    }
}
