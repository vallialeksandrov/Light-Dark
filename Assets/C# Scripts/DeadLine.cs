using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeadLine : MonoBehaviour
{
    public static Action onDiedPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerControl playerControl))
        {
            Destroy(collision.gameObject);
            onDiedPlayer?.Invoke();
        }
    }
}
