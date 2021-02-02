using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanSeeds : MonoBehaviour
{
    //public GameController gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GetComponent<GameController>();
        GameController.playerSeedsTotal = 0;
        GameController.playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
