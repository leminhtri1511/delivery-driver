using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] bool isPackagePickedUp = false;
    [SerializeField] float timePackageGotRemoved = 0.5f;

    [SerializeField] Color32 driverColorHavePackage = new Color32(0, 1, 1, 1);
    [SerializeField] Color32 driverColorDontHavePackage = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D worldObject)
    {
        Debug.Log("object bump");
    }

    void OnTriggerEnter2D(Collider2D colliderObject)
    {
        if (colliderObject.CompareTag("Package") && isPackagePickedUp == false)
        {
            isPackagePickedUp = true;

            Debug.Log("Package picked up !");

            Destroy(colliderObject.gameObject, timePackageGotRemoved);

            spriteRenderer.color = driverColorHavePackage;
        }
        else if (colliderObject.CompareTag("Customer") && isPackagePickedUp == true)
        {
            isPackagePickedUp = false;

            Debug.Log("Delivered package !");

            spriteRenderer.color = driverColorDontHavePackage;
        }
    }
}
