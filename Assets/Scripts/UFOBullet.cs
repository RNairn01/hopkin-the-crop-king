using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        GameObject ufo = GameObject.FindGameObjectWithTag("UFO");
        Physics2D.IgnoreCollision(ufo.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.AddForce(new Vector2(0, -speed * Time.deltaTime), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
