using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject shopMenu;

    // This function will be called when the button is clicked
    public void CloseShop()
    {
        Debug.Log("CloseShop");
        shopMenu.SetActive(false);
    }
}
