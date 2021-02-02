using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   // public static GameController instance;

    static public float playerHealth = 3;
    static public float playerSeedsTotal = 0;
    public float playerSeeds;
    public PlayerMovement player;
    private bool immune;
    public float seedsInLevel;
    private bool isGameOver = false;
    public float knockbackMin;
    public float knockbackMax;
    public Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        playerSeeds = 0;
        player = FindObjectOfType<PlayerMovement>();
        try
        {
            playerAnim = player.GetComponentInParent<Animator>();
        } catch { }
        

        immune = false;
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            playerSeedsTotal = 0;
            playerHealth = 3;
        }
        Debug.Log(playerSeedsTotal);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (playerHealth <= 0 || player.transform.position.y < -10)
            {
                GameOver();
            }
        } catch { }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Application Quit");
        }
    }

    public void Damage()
    {
        if (!immune)
        {
            playerAnim.SetBool("Damaged", true);
            playerHealth--;
            FindObjectOfType<AudioManager>().Play("ScarecrowHurt");
            immune = true;
            Invoke("EndImmune", 2f);
            player.rb.AddForce(new Vector2(0, Random.Range(knockbackMin, knockbackMax)), ForceMode2D.Impulse);
            Invoke("UnDamage", 0.75f);
        }

    }

    void UnDamage()
    {
        playerAnim.SetBool("Damaged", false);
    }

    public void GetSeed()
    {
        playerSeeds++;
        FindObjectOfType<AudioManager>().Play("PickupSeed");
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Game Over!");
            Invoke("LoadOver", 0.2f);
        }
            
    }

    void LoadOver()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("GameOver1");
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("GameOver2");
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("GameOver3");
        }

    }

    public void LoadNextLevel()
    {
        playerSeedsTotal += playerSeeds;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManager>().Play("StartGame");
        player = FindObjectOfType<PlayerMovement>();
    }

    public void Retry()
    {
        playerHealth = 3;
        if (SceneManager.GetActiveScene().name == "GameOver1")
        {
            SceneManager.LoadScene("Level1");
        }
        else if (SceneManager.GetActiveScene().name == "GameOver2")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (SceneManager.GetActiveScene().name == "GameOver3")
        {
            SceneManager.LoadScene("Level3");
        }

    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void GetPumpkin()
    {
        playerHealth++;
        FindObjectOfType<AudioManager>().Play("PickupSeed");
    }

    void EndImmune()
    {
        immune = false;
    }
}
