using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMoverRunner : MonoBehaviour
{
    public float Velocity;
    public bool motion = true;
    public GameObject youWin;
    public float delayTime = 3.0f;

    // Reference to the Interstitial script (AdManager)
    public Interstitial interstitialAdManager;

    private IEnumerator LoadMainMenuWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Show the ad when the player wins
        if (interstitialAdManager != null)
        {
            interstitialAdManager.ShowAd();
        }
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($" OnTriggerEnter {other.gameObject.tag}");
        if (other.gameObject.CompareTag("Finish"))
        {
            youWin.SetActive(true);

            // Call the VictoryAnimation function on the PlayerBehaviour component attached to the player object
            PlayerBehaviour playerBehaviour = FindObjectOfType<PlayerBehaviour>();
            playerBehaviour.VictoryAnimation();
            motion = false;

            StartCoroutine(LoadMainMenuWithDelay(delayTime));
        }
    }

    private void FixedUpdate()
    {
        if (!motion)
        {
            return;
        }

        transform.position += new Vector3(0F, 0F, 0.7F) * Time.deltaTime * Velocity;

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
