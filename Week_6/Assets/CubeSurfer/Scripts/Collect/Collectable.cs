using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static event Action OnCollect;

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f,Time.time * 100f,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Debug.Log(" OnTriggerEnter Collectable");
            OnCollect?.Invoke();
            Destroy(gameObject);
        }
    }
}
