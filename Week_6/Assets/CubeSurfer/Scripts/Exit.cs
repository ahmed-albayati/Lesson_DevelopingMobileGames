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
        // Quit the application
        Debug.Log("exit");
        Application.Quit();
    }
}
