using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FossilPiece : MonoBehaviour
{
    public float integrity;

    public void ApplyIntegrityUpdate(float delta){
        integrity += delta;

        if (integrity <= 0)
            CreateFossilPiece();
    }

    private void CreateFossilPiece() {
        var gameObj = gameObject;
        gameObj.transform.SetParent(null, true);
        gameObj.AddComponent<Rigidbody>();
    }

}
