using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockOn : MonoBehaviour
{
    [SerializeField] GameObject driver;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = driver.transform.position + new Vector3(0, 0, -10);
    }
}
