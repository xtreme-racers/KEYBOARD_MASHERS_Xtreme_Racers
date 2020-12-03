using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //For adding explosion effect
		if(collision.CompareTag("AI") && GlobalManager.bullet == 0)
		{
			GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(effect, 1f);
            AIController Ai = collision.gameObject.GetComponent<AIController>();
            Ai.health -= DamageDealer.playerDamage;
            if(Ai.health <= 0)
            {
                Destroy(collision.gameObject);
            }
			GlobalManager.bullet = 1;
			
		}
		Destroy(gameObject, 2f);
    }
}
