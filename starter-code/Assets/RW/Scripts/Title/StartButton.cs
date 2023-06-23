using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerClickHandler      // REcieve OnPointerClick feedback
{
    public void OnPointerClick(PointerEventData eventData) 
    {
        SceneManager.LoadScene("Game"); 
    }
}
