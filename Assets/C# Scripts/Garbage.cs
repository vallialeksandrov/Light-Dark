using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Garbage : MonoBehaviour
{
    [SerializeField] private Material lightMaterial;

    [SerializeField] private Vector2 nullPosition;
    [SerializeField] private float coefficientIncrease;

    [SerializeField] private bool isFind;

    private void Start() => nullPosition = new Vector2(0, 0);

    private void FixedUpdate()
    {
        if (isFind)
        {
            transform.position = Vector2.MoveTowards(transform.position, nullPosition, 0.25f);
            ChangeProperties();
        }
    }

    private void OnEnable()
    {
        FindGarbage.onFinded += Show;
    }

    private void OnDisable()
    {
        FindGarbage.onFinded -= Show;
    }

    private void Show()
    {      
        gameObject.GetComponent<SpriteRenderer>().material = lightMaterial;
        isFind = true;
    }

    private void ChangeProperties()
    {
        if (transform.position.x != nullPosition.x)
        {
            Vector2 fullScale = transform.localScale;
            fullScale.x += Time.deltaTime / coefficientIncrease;
            fullScale.y += Time.deltaTime / coefficientIncrease;
            transform.localScale = fullScale;
        }
    }
}
