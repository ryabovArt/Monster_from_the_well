using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveWinBlock : MonoBehaviour
{
    //Активация игрового блока при выигрыше
    public void Activate()
    {
        gameObject.SetActive(true);
    }
}
