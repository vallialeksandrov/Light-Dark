using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public static Action<int> onSpawn;

    [Header("Префаб светлячков")]
    [SerializeField] private GameObject fireflyPrefab;

    [Header("Позиция спавна")]
    [SerializeField] private Transform spawnPos;

    [Header("Количество светлячков")]
    [SerializeField] private int amountObject;

    private void Start()
    {
        StartCoroutine(Spawn());
        onSpawn?.Invoke(amountObject); 
    }

    private IEnumerator Spawn()
    {       
        for (int i = 0; i < amountObject; i++)
        {
            yield return new WaitForSeconds(0.3f);
            GameObject newFirefly = Instantiate(fireflyPrefab, spawnPos.position, Quaternion.identity);
        }      
    }
}
