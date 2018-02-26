﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour {

    public int maxPlatforms = 20;
    public GameObject platform;
    public float horizontalMin;
    public float horizontalMax;
    public float verticalMin;
    public float verticalMax;

    Vector2 originPosition;

    void Start() {

    horizontalMin = 5f;
    horizontalMax = 10f;
    verticalMin = -5f;
    verticalMax = 5f;

    originPosition = transform.position;
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }
}
