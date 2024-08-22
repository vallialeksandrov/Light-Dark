using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpiderStamina : MonoBehaviour
{
    public static Action<Vector2> onDied;

    [SerializeField] private float stamina;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > stamina)
        {
            Destroy(gameObject);
            onDied?.Invoke(transform.position);
        }
    }
}
