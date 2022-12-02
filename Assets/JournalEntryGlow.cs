using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalEntryGlow : MonoBehaviour
{
    public float glowRadius;

    private Transform player;

    private Material brightness;

    public float distanceDial;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        brightness = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = transform.position - player.position;

        float distance = offset.magnitude;

        if (distance > glowRadius)
        {
            brightness.color = Color.white;
        }
        else
        {
            brightness.color = Color.yellow / distance * distanceDial;

            print(distance);
        }
    }
}
