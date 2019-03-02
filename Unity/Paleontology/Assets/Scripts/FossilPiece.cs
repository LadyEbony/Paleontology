using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FossilPiece : MonoBehaviour
{
    public float integrity;
    public float mass;

    public FossilController Controller;

    private void Awake() {
        Controller = GetComponentInParent<FossilController>();
    }

    public void ApplyIntegrityUpdate(float delta){
        integrity += delta;

        // Only break once.
        if (Controller && integrity <= 0) {
            Controller.SplitFossilPiece(this);
            Controller = null;
        }
    }


}
