using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondMovement : MonoBehaviour
{
    public float speed = 5;
    public float mag = 0.1f;
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, mag * Mathf.Sin(Time.time * speed));
    }
}
