using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler  // React to event pojnter enter and exit title buttons
{
    public MeshRenderer model; 
    public Color normalColor; 
    public Color hoverColor; 

    // Start is called before the first frame update
    void Start()
    {
        model.material.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData) // Called when pointer enters game object
    {
        model.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)   // Called when pointer exits game object
    {
        model.material.color = normalColor;
    }
}
