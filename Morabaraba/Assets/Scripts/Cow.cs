using System;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class Cow : MonoBehaviour
{
    
    //script from google, basic drag script 
    private Vector3 offset;
    private float zCoord;

    private BoardGenerator bg;
    void OnMouseDown()
    {
        
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPosition();
    }
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset;
        
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord; // Maintain object's Z position
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    //when cow collides with node, will show which node it is interacting with
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("BoardNode"))
        {
            BoardNode node = col.GetComponent<BoardNode>();
            Debug.Log("Cow collided with node:"+node.nodeID);
        }
    }
}

