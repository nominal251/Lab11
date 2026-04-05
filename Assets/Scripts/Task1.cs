using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    public static string[] firstNames = new string[]
    {
        "Carol", "Adam", "Maria", "John", "Leila",
        "Dana", "Durandal", "Michael", "Amos", "James",
        "Naomi", "Gus", "Aedan", "William", "Bryce",
        "Benjamin", "Jack", "Cassian", "Steve", "Alex",
    };

    public static char[] lastInitials = new char[]
    {
        'A','B','C','D','E','F','G','H','I','J','K','L','M',
        'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
    };

    private Queue<string> loginQueue = new Queue<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            loginQueue.Enqueue(GetRandomPlayerName());
        }

        List<string> queueList = loginQueue.ToList();

        string queueNames = string.Join(", ", queueList);
        Debug.Log($"Initial login queue created. There are {loginQueue.Count} players in the queue: {queueNames}.");

        InvokeRepeating("AddPlayer", 2f, 10f);
        InvokeRepeating("LoginPlayer", 1f, 2f);
    }

    void AddPlayer()
    {
        string newPlayer = GetRandomPlayerName();
        loginQueue.Enqueue(newPlayer);
        Debug.Log($"{newPlayer} is trying to login and added to the login queue.");
    }

    void LoginPlayer()
    {
        if (loginQueue.Count > 0)
        {
            string player = loginQueue.Dequeue();
            Debug.Log($"{player} is now inside the game.");
        }
        else
        {
            Debug.Log("Login server is idle. No players are waiting.");
        }
    }



    public static string GetRandomPlayerName()
    {
        string firstName = firstNames[Random.Range(0, firstNames.Length)];
        char lastInitial = lastInitials[Random.Range(0, lastInitials.Length)];
        return $"{firstName} {lastInitial}";
    }
}
