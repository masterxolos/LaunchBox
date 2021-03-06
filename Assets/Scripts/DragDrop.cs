using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DragDrop : MonoBehaviour
{

    private Vector3 mOffset;
    private float mZCoord;
    [SerializeField] private bool gridSettings = true;

    [SerializeField] private GameObject grids;

   

    void OnMouseDown()
    {
        if(gridSettings)
            grids.SetActive(true);
        gameObject.transform.position =
            new Vector3(transform.position.x, transform.position.y + 4.5f, transform.position.z);
        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;
        
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }
    
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }
    
    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    private void OnMouseUp()
    {
        if(gridSettings)
            grids.SetActive(true);
        gameObject.transform.position =
            new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z);
    }
}