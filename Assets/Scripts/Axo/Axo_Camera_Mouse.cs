using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Axo_Camera_Mouse : MonoBehaviour
{
    [SerializeField] private AxisState horizontal_axis;
    [SerializeField] private AxisState vertical_axis;
    [SerializeField] private Transform look_at;
    [SerializeField] private float velocity;
    private void Update()
    {
        horizontal_axis.Update(Time.deltaTime);
        vertical_axis.Update(Time.deltaTime);

        look_at.eulerAngles = new Vector3(vertical_axis.Value, horizontal_axis.Value, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, horizontal_axis.Value, 0), Time.deltaTime * velocity);
    }
}
