using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularSawArea : MonoBehaviour
{
    // Область перемещения циркулярной пилы
    public GameObject leftBorder;
    public GameObject rightBorder;

    private bool isRightDirectiom;

    public float speed;

    void Update()
    {
        if(isRightDirectiom)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x > rightBorder.transform.position.x)
                isRightDirectiom = false;
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < leftBorder.transform.position.x)
                isRightDirectiom = true;
        }
    }
}
