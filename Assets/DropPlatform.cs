using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatform : MonoBehaviour {

    bool droping = false;

    private void Update()
    {
        if (droping == true)
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down, 0.1f);
    }

    void Drop()
    {
        droping = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Invoke("Drop", 1f);
    }
}
