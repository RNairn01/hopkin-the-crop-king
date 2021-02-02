using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackHops : MonoBehaviour
{
    public PlayerMovement player;
    private Slider slider;


    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.hopCounter;
    }
}
