using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Camera_Actions : MonoBehaviour
{
    [SerializeField] private Sling_Attack sling;
    [SerializeField] private CinemachineVirtualCamera cine;
    [SerializeField] private float sub_fov;
    [SerializeField] private float normal_fov;
    [SerializeField] private float time_fov;
    [SerializeField] private float max_fov;
    [SerializeField] private bool is_more = false;
    private void Update()
    {
        StartCoroutine(MoreFov());
        StartCoroutine(LessFov());
    }
    private IEnumerator MoreFov()
    {
        while (sling.holding)
        {
            is_more = true;
            if (cine.m_Lens.FieldOfView > max_fov)
            {
                cine.m_Lens.FieldOfView = cine.m_Lens.FieldOfView - sub_fov;
            }
            yield return new WaitForSeconds(time_fov);
        }
        is_more = false;
    }
    private IEnumerator LessFov()
    {       
        while (cine.m_Lens.FieldOfView < normal_fov && !is_more)
        {
            cine.m_Lens.FieldOfView = cine.m_Lens.FieldOfView + sub_fov;

            yield return new WaitForSeconds(time_fov);
        }
    }

}
