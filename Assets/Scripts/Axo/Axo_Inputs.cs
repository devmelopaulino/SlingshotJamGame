using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axo_Inputs : MonoBehaviour
{
    [SerializeField] public float horizontal_axis;
    [SerializeField] public float raw_horizontal_axis;
    [SerializeField] public float raw_vertical_axis;
    private void Update()
    {
        raw_horizontal_axis = Input.GetAxisRaw("Horizontal");
        raw_vertical_axis = Input.GetAxisRaw("Vertical");
        horizontal_axis = Input.GetAxis("Horizontal");
    }
}
