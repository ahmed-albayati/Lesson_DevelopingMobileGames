using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBF : MonoBehaviour
{
    [SerializeField] float distanceToCover;
    [SerializeField] float speedBF;
    private Vector3 startingPosition;
    void Start()
    {
        startingPosition = transform.position;
    }

    
    void Update()
    {
        Vector3 v = startingPosition;
        v.x = distanceToCover * Mathf.Sin(Time.time * speedBF);
        transform.position = v;
    }
}
