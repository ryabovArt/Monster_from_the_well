using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public ParticleSystem[] effects;

    public void MoveDust()
    {
        StartCoroutine(MoveDustCorutine());
    }

    IEnumerator MoveDustCorutine()
    {
        effects[0].Emit(10);
        yield return new WaitForSeconds(0.5f);
    }

    public void GetStar()
    {
        effects[1].Emit(30);
        Debug.Log("jump");
    }
}
