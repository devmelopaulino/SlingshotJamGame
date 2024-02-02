using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Props : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<Life_Manager>().LessLife(damage);
        }
        Destroy(this.gameObject);
    }
}
