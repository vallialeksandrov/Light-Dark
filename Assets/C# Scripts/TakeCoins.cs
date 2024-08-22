using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TakeCoins : MonoBehaviour
{
    public static Action onTakedCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.TryGetComponent(out PursuitParent pursuitParent))
        {
            Destroy(gameObject);
            onTakedCoin?.Invoke();
        }
    }
}
