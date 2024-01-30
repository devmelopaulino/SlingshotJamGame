using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axo_Inputs : MonoBehaviour
{
    [SerializeField] public float horizontal_axis;
    [SerializeField] public float vertical_axis;
    private void Update()
    {
        horizontal_axis = Input.GetAxisRaw("Horizontal");
        vertical_axis = Input.GetAxisRaw("Vertical");
    }
}
