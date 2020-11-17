using UnityEngine.EventSystems;
using UnityEngine;

public class SwipeHeandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public static float xSpeed;
    public static float ySpeed;

    void Start()
    {
        xSpeed = 0f;
        ySpeed = 0f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        xSpeed = 0f;
        ySpeed = 0f;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
                xSpeed = Mathf.Clamp01(eventData.delta.x);
            else if (eventData.delta.x < 0)
                xSpeed = -Mathf.Clamp01(Mathf.Abs(eventData.delta.x));
        }
        else
        {
            if (eventData.delta.y > 0)
                ySpeed = Mathf.Clamp01(eventData.delta.y);
            else if (eventData.delta.y < 0)
                ySpeed = -Mathf.Clamp01(Mathf.Abs(eventData.delta.y));
            
        }          
    }
}
