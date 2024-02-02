using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Manager : MonoBehaviour
{
    [SerializeField] private float Life;

    public void LessLife(float less)
    {
        Life -= less;   
        if(Life <= 0 )
        {
            Destroy(this.gameObject);
        }
    }
}
