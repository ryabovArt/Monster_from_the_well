using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public BlockBuilder blockBuilder;

    public float timerStart;
    public float spawnLastPlatform;

    void Update()
    {
        GameTimer();
    }

    /// <summary>
    /// Таймер
    /// </summary>
    private void GameTimer()
    {
        timerStart += Time.deltaTime;

        //Ставим блок со звездой по прошествии указанного времени
        if (timerStart > spawnLastPlatform && blockBuilder.isGoDown)
        {
            blockBuilder.isGoDown = false;
        }

    }
}
