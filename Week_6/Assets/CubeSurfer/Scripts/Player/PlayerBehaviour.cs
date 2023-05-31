using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Animator animatorOfPlayer;
    public float reset_delay = 1.0f;
    public PlayerMoverRunner playerMoverRunner;
    private Interstitial interstitial;

    private void Awake()
    {
        Singleton();
        interstitial = GameObject.Find("Interstitial").GetComponent<Interstitial>();
    }

    #region Singleton

    public static PlayerBehaviour Instance;

    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    #endregion

    public void VictoryAnimation()
    {
        Debug.Log("animation");
        animatorOfPlayer.SetTrigger("Victory");

    }

    public void FailAnimation()
    {
        animatorOfPlayer.SetTrigger("Fail");
        ShowInterstitialAd();
        Invoke("Reset", reset_delay);
    }

    private void ShowInterstitialAd()
    {
        if (interstitial != null)
        {
            Debug.Log("Attempting to show interstitial ad.");
            interstitial.ShowAd();
        }
        else
        {
            Debug.LogError("Interstitial ad script not found.");
        }
    }


    void Reset()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StopPlayer()
    {
        DOTween.To(() => playerMoverRunner.Velocity, x => playerMoverRunner.Velocity = x, 0, 0.003f);
    }


}
