using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    void Start()
    {
        // Find the Button component attached to this GameObject
        Button button = GetComponent<Button>();
        // Add an onClick listener to the Button component and call the ExitGame() method when the button is clicked
        button.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        // Print log to console
        Debug.Log("exit");

#if UNITY_EDITOR
        // If in the Unity editor, stop playing the game
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
    // If running on Android, kill the app
    AndroidJavaObject activity = 
      new AndroidJavaClass("com.unity3d.player.UnityPlayer")
      .GetStatic<AndroidJavaObject>("currentActivity");
    activity.Call<bool>("finish");
#else
    // If on any other platform, quit the application
    Application.Quit();
#endif
    }


}
