using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularSawRotation : MonoBehaviour
{
    //Скорость вращения циркулярной пилы
    public float rotation;

    void Update()
    {
        transform.Rotate(0, 0, rotation);
    }
}
