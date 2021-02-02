using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFire : MonoBehaviour
{
    public float fireRate;
    public UFOBullet bullet;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", fireRate, fireRate);
        player = FindObjectOfType<PlayerMovement>();
    }

    void Fire()
    {
        Instantiate(bullet, new Vector2(transform.position.x, transform.position.y - 1f), Quaternion.Euler(new Vector3(0, 0, 90)));
        if (Vector2.Distance(player.transform.position, transform.position) <= 30)
        {
            FindObjectOfType<AudioManager>().Play("AlienShoot");
        }
        
    }
}
