using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactDamager : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        Life life = other.GetComponent<Life>();

        if (life != null)
        {
            life.amount -= damage;
        }
    }
}
