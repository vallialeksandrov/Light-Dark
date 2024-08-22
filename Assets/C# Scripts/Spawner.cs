using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public static Action<int> onSpawn;

    [Header("������ ����������")]
    [SerializeField] private GameObject fireflyPrefab;

    [Header("������� ������")]
    [SerializeField] private Transform spawnPos;

    [Header("���������� ����������")]
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
