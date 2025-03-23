using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 280f;
    [SerializeField] float moveSpeed = 10f;

    void OnCollisionEnter2D(Collision2D worldObject)
    {
        moveSpeed--;
        Debug.Log("Speed decreasing: " + moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D boostSpeedPoint)
    {
        if (boostSpeedPoint.CompareTag("BoostSpeedPoint"))
        {
            moveSpeed++;
            Debug.Log("Speed increasing: " + moveSpeed);
        }
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
