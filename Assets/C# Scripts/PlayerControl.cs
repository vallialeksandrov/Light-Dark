using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    private void OnMouseDrag()
    {
        Vector2 cursorPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}
