using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopMenu;

    // This function will be called when the button is clicked
    public void OpenShop()
    {
        Debug.Log("OpenShop");
        shopMenu.SetActive(true);
    }
}

