using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelTarget : MonoBehaviour
{
    [SerializeField] private float speed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PursuitParent pursuitParent))
        {
            collision.transform.position = Vector2.MoveTowards(collision.transform.position, transform.position, speed);
        }
    }
}
