using UnityEngine;

public class CowSpawner : MonoBehaviour
{
    public GameObject cowPrefab;

    // which player these cows belong to
    public int playerNumber;

    // number of cows per player
    public int numberOfCows = 12;

    // where the first cow starts
    public Vector2 startPosition;



    void Start()
    {
        for (int i = 0; i < numberOfCows; i++)
        {
            Vector2 spawnPos = new Vector2(startPosition.x,startPosition.y);

            GameObject cow = Instantiate(cowPrefab, spawnPos, Quaternion.identity, transform);

            // assign the cow's player
            Cow cowScript = cow.GetComponent<Cow>();
            cowScript.playerNumber = playerNumber;
        }
    }
}