using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaminaFlyfire : MonoBehaviour
{
    public static Action<Vector2> onDiedPosition;
    public static Action onEndedLife;

    [SerializeField] private float stamina;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out AngelTarget angelTarget))
        {
            if (collision.relativeVelocity.magnitude > stamina)
            {
                onDiedPosition?.Invoke(transform.position);
                onEndedLife?.Invoke();

                Destroy(gameObject);
            }
        }
    }
}
