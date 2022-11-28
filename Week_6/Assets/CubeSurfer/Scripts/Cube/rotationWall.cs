using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationWall : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 200f, 0);
    }
}
