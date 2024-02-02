using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort_Material : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    [SerializeField] private MeshRenderer meshRenderer;
    private void Start()
    {
        int randomIndex = Random.Range(0, materials.Length);
        Material[] meshMaterials = meshRenderer.materials;
        meshMaterials[0] = materials[randomIndex];
        meshRenderer.materials = meshMaterials;
    }
}
