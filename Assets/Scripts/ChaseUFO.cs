using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseUFO : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(10000, transform.position.y), speed * Time.deltaTime);
    }
}
