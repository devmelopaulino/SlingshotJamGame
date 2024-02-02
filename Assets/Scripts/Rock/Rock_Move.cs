using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rock_Move : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private float velocity;
    public void Move(Vector3 direction)
    {
        body.velocity = direction * velocity;
    }
}
