using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMove : MonoBehaviour
{
    public float radius = 10f;
    private Vector2 center;
    private float angle;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveInCircle();
    }

    void MoveInCircle()
    {
        angle += speed * Time.deltaTime;
        Vector2 offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = center + offset;
    }
}
