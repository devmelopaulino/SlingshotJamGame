using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Props : MonoBehaviour
{
    [SerializeField]public Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
