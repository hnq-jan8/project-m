using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUICameraZoom : MonoBehaviour
{
    [SerializeField] [Range(1300, 1600)] private float zoomOutScale; 
    [SerializeField] [Range(630, 730)] private float zoomInScale;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float currentZoomScale;
    [SerializeField] private float nextZoomScale;
    [SerializeField] private KeyCode zoomKey;
    [SerializeField] private bool isZoomedIn = false;

    // Start is called before the first frame update
    void Start()
    {
        nextZoomScale = zoomOutScale;
    }

    // Update is called once per frame
    void Update()
    {
        currentZoomScale = GetComponent<Camera>().orthographicSize;

        if (Input.GetKeyDown(zoomKey))
        {
            if(isZoomedIn == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }

        currentZoomScale = Mathf.Lerp(currentZoomScale, nextZoomScale, zoomSpeed * Time.deltaTime);
        GetComponent<Camera>().orthographicSize = currentZoomScale;
    }

    void ZoomIn()   //orthographicSize decrease
    {
        Debug.Log("a");
        nextZoomScale = zoomInScale;
        isZoomedIn = true;
    }

    void ZoomOut()  //orthographicSize increase
    {
        Debug.Log("b");
        nextZoomScale = zoomOutScale;
        isZoomedIn = false;
    }

    public void ResetZoom()
    {
        currentZoomScale = zoomOutScale;
        nextZoomScale = zoomOutScale;
        GetComponent<Camera>().orthographicSize = 1500;
        isZoomedIn = false;
    }
}
