using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Attack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Enemy_Move enemy;
    [SerializeField] public bool attacking;
    //private void Update()
    //{
    //    attacking = enemy.arrive;
    //}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<Life_Manager>().LessLife(damage);
        }
    }

}
