using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndKill : MonoBehaviour
{
    public static float GameTimer;
    public static int EnemyKill;

    private void Update()
    {
        GameTimer += Time.deltaTime;
    }

    public static void IncrementEnemyKill()
    {
        EnemyKill++;
    }
}
