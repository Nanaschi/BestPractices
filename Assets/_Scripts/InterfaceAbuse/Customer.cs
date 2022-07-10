using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Customer : MonoBehaviour, IPointerClickHandler 
{
    public void OnPointerClick(PointerEventData eventData)
    {
        print("clicked");
    }
}
