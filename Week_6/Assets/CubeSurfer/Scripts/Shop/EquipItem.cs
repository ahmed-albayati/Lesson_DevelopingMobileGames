using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipItem : MonoBehaviour
{
    public Button equipButton;
    public Color equippedColor = Color.green;
    public Color unequippedColor = Color.red;
    public TextMeshProUGUI buttonText;
    public Image mainMenuImage;
    public Sprite originalSprite;
    public Sprite equippedSprite;
    private bool isItemEquipped = false;

    private void Start()
    {
        // Get item state from PlayerPrefs
        isItemEquipped = PlayerPrefs.GetInt("IsItemEquipped", 0) == 1;
        UpdateMainMenuImage();
    }

    public void OnEquipButtonClick()
    {
        // Check if equipButton is active in hierarchy
        if (equipButton.gameObject.activeInHierarchy)
        {
            // Get the current colors of the button
            ColorBlock buttonColors = equipButton.colors;

            if (!isItemEquipped)
            {
                Debug.Log("Equipped item.");
                isItemEquipped = true;
                PlayerPrefs.SetInt("IsItemEquipped", 1);

                // Set all the button's colors to equippedColor
                buttonColors.normalColor = equippedColor;
                buttonColors.highlightedColor = equippedColor;
                buttonColors.pressedColor = equippedColor;
                buttonColors.selectedColor = equippedColor;
            }
            else
            {
                Debug.Log("Item not equipped anymore.");
                isItemEquipped = false;
                PlayerPrefs.SetInt("IsItemEquipped", 0);

                // Set all the button's colors to unequippedColor
                buttonColors.normalColor = unequippedColor;
                buttonColors.highlightedColor = unequippedColor;
                buttonColors.pressedColor = unequippedColor;
                buttonColors.selectedColor = unequippedColor;
            }

            // Apply the changes to the button's colors
            equipButton.colors = buttonColors;

            // Update the button text and main menu image
            UpdateButtonText();
            UpdateMainMenuImage();
        }
    }

    private void UpdateButtonText()
    {
        buttonText.text = isItemEquipped ? "Unequip" : "Equip";
    }

    private void UpdateMainMenuImage()
    {
        mainMenuImage.sprite = isItemEquipped ? equippedSprite : originalSprite;
    }
}
