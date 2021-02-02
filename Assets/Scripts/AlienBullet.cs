using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    public PlayerMovement player;
    private Rigidbody2D rb;
    public float speed;
    Vector2 moveDirection;
    public GameObject alien;
    public Transform target;
    Vector3 relativeTarget;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        

        Physics2D.IgnoreCollision(alien.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        player = FindObjectOfType<PlayerMovement>();
        
        rb = GetComponent<Rigidbody2D>();
        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

        target = player.GetComponent<Transform>();
        relativeTarget = (target.position - transform.position).normalized;
    }

    private void Update()
    {
        angle = Mathf.Atan2(-relativeTarget.y, -relativeTarget.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Alien")
        {
            return;
        } else
        {
            Destroy(gameObject);
        }
            

}
}
