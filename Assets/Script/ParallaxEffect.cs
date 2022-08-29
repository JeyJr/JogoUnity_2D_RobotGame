using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxValue;

    Transform player;

    private void OnEnable()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x * parallaxValue, transform.position.y, transform.position.z);
    }
}
