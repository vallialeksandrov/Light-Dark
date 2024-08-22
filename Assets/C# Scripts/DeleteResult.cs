using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteResult : MonoBehaviour
{
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
