using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentPlayer = 1;

    private void Awake()
    {
        Instance = this;
    }

    public void EndTurn()
    {
        if (currentPlayer == 1)
            currentPlayer = 2;
        else
            currentPlayer = 1;

        Debug.Log("Now it is Player " + currentPlayer + "'s turn");
    }

    public void RegisterPlacement(int player)
    {
        Debug.Log("Player " + player + " placed a cow");
    }
}