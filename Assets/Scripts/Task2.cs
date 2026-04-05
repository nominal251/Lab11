using System.Collections.Generic;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    public static string[] firstNames = new string[]
    {
        "Carol", "Adam", "Maria", "John", "Leila",
        "Dana", "Durandal", "Michael", "Amos", "James",
        "Naomi", "Gus", "Aedan", "William", "Bryce",
        "Benjamin", "Jack", "Cassian", "Steve", "Alex",
    };

    void Start()
    {
        string[] randomNames = new string[15];

        for (int i = 0; i < randomNames.Length; i++)
        {
            int randomIndex = Random.Range(0, firstNames.Length);
            randomNames[i] = firstNames[randomIndex];
        }

        Debug.Log("Created the name array: " + string.Join(", ", randomNames));

        HashSet<string> seen = new HashSet<string>();
        HashSet<string> duplicates = new HashSet<string>();

        foreach (string name in randomNames)
        {
            if (!seen.Add(name))
            {
                duplicates.Add(name);
            }
        }

        if (duplicates.Count > 0)
        {
            Debug.Log("The array has duplicate names: " + string.Join(", ", duplicates));
        }
        else
        {
            Debug.Log("The array has no duplicate names.");
        }
    }
}
