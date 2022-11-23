
using UnityEngine;

public class PlayerMoverRunner : MonoBehaviour
{
    public float Velocity;
    public bool motion = true;
    public GameObject youWin;

    private void OnTriggerEnter(Collider other)
    {
       Debug.Log($" OnTriggerEnter {other.gameObject.tag}" );
        if (other.gameObject.CompareTag("Finish")){
            youWin.SetActive(true);
            motion = false;
        }
    }

    private void FixedUpdate()
    {
        if (!motion)
        {
            return;
        }
   

        transform.position += new Vector3(0F, 0F, 1F) * Time.deltaTime * Velocity;

        if (transform.position.x > 0.14F)
        {
            transform.position = new Vector3(0.14f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -0.14F)
        {
            transform.position = new Vector3(-0.14f, transform.position.y, transform.position.z);
        }
    }
}
