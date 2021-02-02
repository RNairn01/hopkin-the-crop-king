using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMove : MonoBehaviour
{
    private float min;
    private float max;
    public float range;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + range;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveUFO();
    }

    void MoveUFO()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y);
        
    }
}
