using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SpiderSound : MonoBehaviour
{
    [SerializeField] private AudioSource spiderAS;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PursuitParent pursuitParent))
            spiderAS.Play();
    }
}
