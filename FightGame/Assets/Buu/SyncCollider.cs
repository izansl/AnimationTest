using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMeshCollider : MonoBehaviour
{
    public MeshFilter targetMeshFilter; // La malla objetivo
    public MeshCollider targetMeshCollider; // El MeshCollider que se debe actualizar

    void Update()
    {
        if (targetMeshFilter != null && targetMeshCollider != null)
        {
            // Actualiza el colisionador con la malla actualizada
            targetMeshCollider.sharedMesh = null;
            targetMeshCollider.sharedMesh = targetMeshFilter.mesh;
        }
    }
}