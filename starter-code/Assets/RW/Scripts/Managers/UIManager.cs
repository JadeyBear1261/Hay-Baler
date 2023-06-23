using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;   // Reference this UI manager

    public Text sheepSavedText;     // Cache reference to text of SavedSheepText5
    public Text sheepDroppedText;       //Cache reference to text of DroopedSheepText
    public GameObject gameOverWindow;   //Reference Game Over window
    
    // Awake calld before start
    void Awake()
    {
        Instance = this;
    }

    public void UpdateSheepSaved()      // Update UI 
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped() 
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void ShowGameOverWindow()    // Activates window upon game over
    {
        gameOverWindow.SetActive(true);
    }
}
