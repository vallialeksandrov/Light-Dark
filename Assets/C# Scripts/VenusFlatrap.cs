using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VenusFlatrap : MonoBehaviour
{
    public static Action onDied;
    public static Action<Vector2> onDiedPosition;

    [SerializeField] private Animator venusAnim;

    [SerializeField] private bool isEating;

    [SerializeField] private GameObject lightFirefly;

    private void Start() => venusAnim = GetComponent<Animator>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isEating == false)
        {
            if (collision.TryGetComponent(out PursuitParent pursuitParent))
            {
                venusAnim.SetBool("isFind", true);
                
                StartCoroutine(PlayIdleAnimation());
                lightFirefly.SetActive(true);

                Destroy(collision.gameObject);
                onDied?.Invoke();
                onDiedPosition?.Invoke(collision.transform.position);

                isEating = true;
            }
        }
    }

    private IEnumerator PlayIdleAnimation()
    {
        yield return new WaitForSeconds(2f);
        venusAnim.SetBool("isFind", false);     
    }
}
