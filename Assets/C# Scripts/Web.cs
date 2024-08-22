using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    [Header("Паук на паутине")]
    [SerializeField] private Spider spider;

    [Header("Количество жертв в паутине")]
    [SerializeField] private int countVictim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PursuitParent pursuitParent))
        {
            Rigidbody2D collisionRigid = collision.GetComponent<Rigidbody2D>();
            collisionRigid.drag = 5f;
            collisionRigid.angularDrag = 10f;

            countVictim += 1;
        }
        CheckWeb();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PursuitParent pursuitParent))
        {
            spider.CatchVictim(collision.transform.position);          
        }
        CheckWeb();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PursuitParent pursuitParent))
        {
            Rigidbody2D collisionRigid = collision.GetComponent<Rigidbody2D>();
            collisionRigid.drag = 0f;
            collisionRigid.angularDrag = 0f;

            countVictim -= 1;
        }
        CheckWeb();
    }

    private void CheckWeb()
    {
        if (countVictim == 0)
            spider.Back();
    }
}
