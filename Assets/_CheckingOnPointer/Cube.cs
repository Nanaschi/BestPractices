using UnityEngine;
using UnityEngine.EventSystems;

namespace RiseMine
{
    public class Cube : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("You clicked on me");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("You clicked on me");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
