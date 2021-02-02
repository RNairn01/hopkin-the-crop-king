using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public GameController gameManager;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameController>();
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {

                gameManager.Damage();
        }

        if (collision.collider.tag == "Crow")
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.9)
                {
                    Destroy(collision.gameObject);
                    player.rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                    FindObjectOfType<AudioManager>().Play("CrowPass");
                }
                else gameManager.Damage();
            }
        }

        if (collision.collider.tag == "Alien" || collision.collider.tag == "UFO")
        {

            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.9)
                {
                    Destroy(collision.gameObject);
                    player.rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                    if (collision.collider.tag == "Alien") FindObjectOfType<AudioManager>().Play("AlienDieAlt");
                    else FindObjectOfType<AudioManager>().Play("AlienDie");
                }
                else gameManager.Damage();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Seed")
        {
            gameManager.GetSeed();
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Pumpkin")
        {
            gameManager.GetPumpkin();
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Pond")
        {
            gameManager.GameOver();
        }

        if (collision.tag == "EndBox")
        {
            Debug.Log("Stage Complete");
            Invoke("LoadNext", 1.5f);
            
        }
    }

    void LoadNext()
    {
        gameManager.LoadNextLevel();
    }
}
