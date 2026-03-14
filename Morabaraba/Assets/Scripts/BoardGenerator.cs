using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public GameObject nodePrefab;
    // This is not the cow , this is the node on the board where a cow can sit 

    //create a 2D array to store nodes at all 24 possible positions
    //of the board 
    private Vector2[] nodePositions =
    {
        //going clockwise for all squares (24 nodes in total) 
        //Outer Square
        new Vector2(-4.2f,4.23f),new Vector2(0,4.23f),new Vector2(4.2f,4.23f),
        new Vector2(4.2f,0),new Vector2(4.2f,-4.29f),new Vector2(0,-4.3f),
        new Vector2(-4.26f,-4.3f),new Vector2(-4.26f,0),
        //Middle Square 
        new Vector2(-2.84f,2.84f),new Vector2(0,2.84f),new Vector2(2.84f,2.84f),
        new Vector2(2.84f,0),new Vector2(2.84f,-2.78f),new Vector2(0,-2.78f),
        new Vector2(-2.81f,-2.78f),new Vector2(-2.81f,0),
        
        //Inner Square 
        new Vector2(-1.42f,1.38f),new Vector2(0,1.38f),new Vector2(1.35f,1.38f),
        new Vector2(1.35f,0),new Vector2(1.35f,-1.37f),
        new Vector2(0,-1.37f),new Vector2(-1.39f,-1.37f),new Vector2(-1.39f,0),
    };

    void Start()
    {
        //for loop that instantiates all 24 nodes and assigns them node IDs
        for (int i = 0; i < nodePositions.Length; i++)
        {
            GameObject node = Instantiate(nodePrefab, nodePositions[i], Quaternion.identity, transform);
            BoardNode nodeScript = node.GetComponent<BoardNode>();
            //better if boardnode in separate script so each node stores its
            //own information, making design later easier
            nodeScript.nodeID = i;
            //Debug.Log("Node ID: "+nodeScript.nodeID);
        }
    }

}
