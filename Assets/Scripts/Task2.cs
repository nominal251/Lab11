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

        Debug.Log("Random 15 names: " + string.Join(", ", randomNames)); //testing line
    }
}
