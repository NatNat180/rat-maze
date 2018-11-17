using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitch : MonoBehaviour
{

    public Rigidbody movableWall;

    private void OnTriggerEnter(Collider other)
    {
        if ("Rat".Equals(other.tag))
        {
            movableWall.transform.Rotate(Vector3.right * Time.deltaTime);
        }
    }
}
