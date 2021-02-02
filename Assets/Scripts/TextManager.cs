using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text health;
    public Text seeds;
    public GameController gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        health.text = $"{GameController.playerHealth}";
        seeds.text = $"{gameManager.playerSeeds}/{gameManager.seedsInLevel}";
    }
}
