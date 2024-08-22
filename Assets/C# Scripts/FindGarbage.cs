using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class FindGarbage : MonoBehaviour
{
    public static Action onFinded, onDeleted;
      
    [SerializeField] private int countGarbage;

    private void Start() => countGarbage = PlayerPrefs.GetInt("Garbage");

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AngelTarget angelTarget))
        {            
            onFinded?.Invoke();
        
            countGarbage++;
            PlayerPrefs.SetInt("Garbage", countGarbage);

            StartCoroutine(DestroyObject());
        }
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3f);
        onDeleted?.Invoke();
        Destroy(gameObject);
    }
}
