using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cordyceps : MonoBehaviour
{
    public static Action<GameObject> onInfected;
    public static Action onKilled;

    [HideInInspector] private Collision2D collision;

    private void OnCollisionEnter2D(Collision2D currentCollision)
    {
        collision = currentCollision;

        if (collision.gameObject.TryGetComponent(out PursuitParent pursuitParent))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;

            PursuitParent pursuitParentOnObject = collision.gameObject.GetComponent<PursuitParent>();
            Destroy(pursuitParentOnObject);

            collision.gameObject.AddComponent<Cordyceps>();
            GameObject newInfectedObject = collision.transform.gameObject;

            onInfected?.Invoke(newInfectedObject);
            onKilled?.Invoke();
        }         
    }
}
