using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling_Inputs : MonoBehaviour
{
    [SerializeField] public bool left_click_hold;
    [SerializeField] public bool left_click_up;
    void Update()
    {
        left_click_hold = Input.GetMouseButton(0);

    }
}
