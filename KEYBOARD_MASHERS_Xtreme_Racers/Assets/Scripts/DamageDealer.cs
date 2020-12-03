using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public static int playerDamage = 20;
    public static int enemyDamage = 10;

    public int GetPlayerDamage()
    {
        return playerDamage;
    }

    public int GetEnemyDamage()
    {
        return enemyDamage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
