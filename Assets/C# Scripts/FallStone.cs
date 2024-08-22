using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallStone : MonoBehaviour
{
    [SerializeField] private Rigidbody2D stoneRigid;

    private void Start()
    {
        stoneRigid = GetComponent<Rigidbody2D>();
        stoneRigid.isKinematic = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        stoneRigid.isKinematic = false;
    }
}
