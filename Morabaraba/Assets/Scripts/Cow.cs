using System;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class Cow : MonoBehaviour
{

    //script from google, basic drag script 
    private Vector3 offset;
    private float zCoord;

    private BoardGenerator bg;

    private Vector3 startPosition;
    private BoardNode hoveredNode;
    private BoardNode placedNode;

    private bool isPlaced = false;

    //which player this cow belongs to
    public int playerNumber;

    //used to stop dragging if it isn't this player's turn
    private bool isDragging = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    void OnMouseDown()
    {
        if (isPlaced) return;

        //only allow dragging if it is this player's turn
        if (GameManager.Instance.currentPlayer != playerNumber)
        {
            Debug.Log("Not Player " + playerNumber + "'s turn");
            return;
        }

        isDragging = true;

        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        if (isPlaced) return;

        if (!isDragging) return;

        transform.position = GetMouseWorldPosition() + offset;

    }

    void OnMouseUp()
    {
        if (isPlaced) return;

        if (!isDragging) return;

        isDragging = false;

        // If released over a valid empty node, snap to it
        if (hoveredNode != null && !hoveredNode.isOccupied)
        {
            transform.position = hoveredNode.transform.position;
            hoveredNode.isOccupied = true;
            placedNode = hoveredNode;
            isPlaced = true;

            Debug.Log("Cow placed on node: " + placedNode.nodeID);

            //tell the game manager that a cow was placed
            GameManager.Instance.RegisterPlacement(playerNumber);

            //switch turn
            GameManager.Instance.EndTurn();
        }
        else
        {
            // Invalid drop, return to original position
            transform.position = startPosition;
            Debug.Log("Invalid placement, returning cow.");
        }
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
            hoveredNode = col.GetComponent<BoardNode>();
            Debug.Log("Hovering over node: " + hoveredNode.nodeID);
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("BoardNode"))
        {
            BoardNode node = col.GetComponent<BoardNode>();

            if (hoveredNode == node)
            {
                hoveredNode = null;
            }
        }
    }
}