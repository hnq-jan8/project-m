using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListScroll : MonoBehaviour
{
    [SerializeField] private int numberOfContent;
    [SerializeField] private float scrollDistance;
    private RectTransform rectTransform;

    private Vector2 originalPos;

    private bool pressed = false;
    private int currentSlot = 0;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && pressed == false && currentSlot > 0)
        {
            Vector2 newPos = new Vector2(rectTransform.position.x, rectTransform.position.y - scrollDistance);
            rectTransform.position = newPos;
            pressed = true;
            currentSlot--;
        }
        else if(Input.GetKeyDown(KeyCode.S) && pressed == false && currentSlot < numberOfContent-1)
        {
            Vector2 newPos = new Vector2(rectTransform.position.x, rectTransform.position.y + scrollDistance);
            rectTransform.position = newPos;
            pressed = true;
            currentSlot++;
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            //Debug.Log("Reset");
            pressed = false;
        }
    }

    public void ResetScrollPosition()
    {
        rectTransform.position = originalPos;
        currentSlot = 0;
    }
    public void DecreaseNumberOfContent()
    {
        numberOfContent--;
    }
}
