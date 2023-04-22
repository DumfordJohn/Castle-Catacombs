using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{
    public class Enemy : MonoBehaviour
    {
        public int health = 3;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Projectile"))
            {
                health -= 1;

                if (health <= 0)
                {
                    // Destroy the enemy game object
                    Destroy(gameObject);
                }
            }
        }
    }
}
