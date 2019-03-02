using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(SkinnedMeshRenderer))]
public class SkinnedMeshCollider : MonoBehaviour
{
    private MeshCollider meshCollider;
    private SkinnedMeshRenderer meshRenderer;
    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
