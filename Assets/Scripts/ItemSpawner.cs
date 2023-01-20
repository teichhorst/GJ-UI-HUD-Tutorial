using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    public float healthRatio;

    public Vector2 spawnTimeRange;
    
    public Vector2 gravityRange;

    public Vector2 spawnYRange;
    public Vector2 spawnXRange;

    private Coroutine spawnItemsHandler;

    public GameObject fireball;
    public GameObject heart;

    private void OnEnable()
    {
        spawnItemsHandler = StartCoroutine(SpawnItemsRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(spawnItemsHandler);
    }

    private IEnumerator SpawnItemsRoutine()
    {
        while (true)
        {
            float timer = Random.Range(spawnTimeRange.x, spawnTimeRange.y);

            yield return new WaitForSeconds(timer);

            SpawnItem();
        }
    }
    
    
    private void SpawnItem()
    {
        if (Random.value <= healthRatio)
        {
            Instantiate(heart, new Vector3(Random.Range(spawnXRange.x, spawnXRange.y), Random.Range(spawnYRange.x, spawnYRange.y), 0), quaternion.identity);
        }
        else
        {
            Instantiate(fireball, new Vector3(Random.Range(spawnXRange.x, spawnXRange.y), Random.Range(spawnYRange.x, spawnYRange.y), 0), quaternion.identity);
        }
    }
}
