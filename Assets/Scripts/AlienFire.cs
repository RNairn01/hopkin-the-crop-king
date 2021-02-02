using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFire : MonoBehaviour
{
    public PlayerMovement player;
    public AlienBullet bullet;
    public float fireDelay;
    public float fireRate;
    public float fireRange;
    Animator animator;
   // Vector3 rotation;
   // public float maxRad;
    //public float magnitude;
   // Quaternion q;
   // Vector3 vectorToTarget;


    // Start is called before the first frame update
    void Start()
    {
      //  vectorToTarget = player.transform.position - transform.position;
      //  float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
      //  q = Quaternion.AngleAxis(angle, Vector3.forward);


        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>();
        InvokeRepeating("Fire", fireDelay, fireRate);
       // rotation = Vector3.RotateTowards(transform.position, player.transform.position, maxRad, magnitude);
    }

    void Fire()
    {
        
        if (Vector2.Distance(player.transform.position, transform.position) <= fireRange && player.transform.position.y >= (transform.position.y -5))
        {
            animator.SetBool("firing", true);
            FindObjectOfType<AudioManager>().Play("AlienShootAlt");
            Invoke("Bullet", 1f);
        }
    }

    void Bullet()
    {
        Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        animator.SetBool("firing", false);
    }
}
