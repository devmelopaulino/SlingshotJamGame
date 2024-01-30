using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axo_Move : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private Axo_Inputs inputs;
    [SerializeField] private float velocity;
    [SerializeField] public bool walking;
    private void Update()
    {
        Vector3 direction = transform.TransformDirection(inputs.horizontal_axis, 0,inputs.vertical_axis).normalized;
        body.velocity = Time.deltaTime * velocity * direction;
        walking = body.velocity.sqrMagnitude > 0;
    }
}
