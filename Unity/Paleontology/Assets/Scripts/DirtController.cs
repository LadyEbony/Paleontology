using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{
    public GameObject DirtPrefab;

    public float x, y, z;
    public float length, width, height;

    [ContextMenu("Spawn")]
    private void SpawnDirts(){
        var children = new List<GameObject>();
        foreach (Transform child in transform)
            children.Add(child.gameObject);
        children.ForEach(child => DestroyImmediate(child));

        var basePos = transform.position;
        var xStart = -(x - 1) * (length / 2);
        var zStart = -(z - 1) * (width / 2);
        for (var i = 0; i < x; i++){
            for(var j = 0; j < y; j++){
                for (var k = 0; k < z; k++) {
                    Instantiate(DirtPrefab, basePos + new Vector3(xStart + length * i, height * j, zStart + width * k), Quaternion.identity, transform);
                }
            }
        }
    }

}
