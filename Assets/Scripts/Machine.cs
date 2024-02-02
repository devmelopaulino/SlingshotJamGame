using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private GameObject Gum;
    [SerializeField] private Transform spawnpoint;
    public void Spawn()
    {
        GameObject new_gum = Gum;
        Instantiate(new_gum,spawnpoint.position, Quaternion.identity);
    }
}
