using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public static Action onKilled;
    public static Action<Vector2> onKilledPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PursuitParent pursuitParent))
        {
            Destroy(collision.gameObject);

            onKilled?.Invoke();
            onKilledPosition?.Invoke(collision.transform.position);
        }
    }
}
