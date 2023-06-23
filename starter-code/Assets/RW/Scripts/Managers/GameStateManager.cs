using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      // Allows use of scene related methods

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; 

    [HideInInspector]
    public int sheepSaved;  // Sheep saved by hay

    [HideInInspector]
    public int sheepDropped; 

    public int sheepDroppedBeforeGameOver;  // Game over sheep dropped number
    public SheepSpawner sheepSpawner; 

    // Awake is called before start
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //Load title screen with escape key
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();  // Updates text to show sheep saved
    }

    private void GameOver()     // Called after sheep dropped exceeds SheepDroppedBeforeGameOver
    {
        sheepSpawner.canSpawn = false; 
        sheepSpawner.DestroyAllSheep(); 
        UIManager.Instance.ShowGameOverWindow();
    }

    public void DroppedSheep()      // Called when sheep drops, incrementing sheepDropped variable
    {
        sheepDropped++; 
        UIManager.Instance.UpdateSheepDropped();

        if (sheepDropped == sheepDroppedBeforeGameOver)   //If number equals allowed number, game over
        {
            GameOver();
        }
    }
}
