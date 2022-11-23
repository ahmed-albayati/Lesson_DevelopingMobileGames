using DG.Tweening;

using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Animator animatorOfPlayer;
    public float reset_delay = 1.0f;
    public PlayerMoverRunner playerMoverRunner;

    private void Awake()
    {
        Singleton();
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
        animatorOfPlayer.SetTrigger("Victory");

    }

    public void FailAnimation()
    {
        animatorOfPlayer.SetTrigger("Fail");
        Invoke("Reset", reset_delay);
    }
    void Reset()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void StopPlayer()
    {
        DOTween.To(() => playerMoverRunner.Velocity, x => playerMoverRunner.Velocity = x, 0, 0.003f);
    }


}
