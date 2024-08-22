using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Spider : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 startPosition;

    [SerializeField] private Animator spiderAnim;

    private void Start()
    {
        spiderAnim = GetComponent<Animator>();
        startPosition = transform.position;
    }

    public void CatchVictim(Vector2 victimPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, victimPosition, speed);

        Vector3 relative = transform.InverseTransformPoint(victimPosition);
        float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle);

        spiderAnim.SetBool("isFind", true);      
    }

    public void Back()
    {
        Vector2 spiderPosition = transform.position;

        if (spiderPosition == startPosition)
        {
            spiderAnim.SetBool("isFind", false);
        }

        else if (spiderPosition != startPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, speed);

            Vector3 relative = transform.InverseTransformPoint(startPosition);
            float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, -angle);
        }
    }   
}
