using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    List<string> deckList = new List<string>
        {
            "K\u2660", "Q\u2660", "J\u2660", "A\u2660", // spades
            "K\u2663", "Q\u2663", "J\u2663", "A\u2663", // clubs
            "K\u2665", "Q\u2665", "J\u2665", "A\u2665", // hearts
            "K\u2666", "Q\u2666", "J\u2666", "A\u2666"  // diamonds
        };

    List<string> playerHand = new List<string>();

    private int endGame = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deckList = deckList.OrderBy(x => Random.value).ToList();

        Stack<string> deckStack = new Stack<string>(deckList);

        Debug.Log("<color=white>Shuffled deck: " + string.Join(", ", deckStack));

        for (int i = 0; i < 4; i++)
        {
            if (deckStack.Count > 0)
            {
                playerHand.Add(deckStack.Pop());
            }
        }

        Debug.Log("<color=white>I made the initial deck and draw. My hand is: " + string.Join(", ", playerHand));

        if (HasAllSuits(playerHand))
        {
            Debug.Log("<color=#6eff72>My initial hand won!");
            endGame = 1;
        }

        while (deckStack.Count > 0 && endGame == 0)
        {
            int randomIndex = Random.Range(0, playerHand.Count);

            string CardToDiscard = playerHand[randomIndex];
            playerHand.RemoveAt(randomIndex);

            string CardToAdd = deckStack.Pop();
            playerHand.Add(CardToAdd);

            if (HasAllSuits(playerHand))
            {
                Debug.Log($"<color=#6eff72>I discarded {CardToDiscard} and drew {CardToAdd}. My hand is: " + string.Join(", ", playerHand) + ". The game is WON.");
                endGame = 1;
            }
            else
            {
                Debug.Log($"<color=#ffe46e>I discarded {CardToDiscard} and drew {CardToAdd}. My hand is: " + string.Join(", ", playerHand) + ". This is not a winning hand. I will attempt to play another round.");
                Debug.Log("<color=white>New deck: " + string.Join(", ", deckStack));

                if (deckStack.Count == 0)
                {
                    Debug.Log("<color=#ff6e6e>The deck is empty. The game is LOST.");
                    endGame = 1;
                }
            }
        }
    }

    bool HasAllSuits(List<string> hand)
    {
        return hand.Any(card => card.EndsWith("\u2660")) &&
               hand.Any(card => card.EndsWith("\u2663")) &&
               hand.Any(card => card.EndsWith("\u2665")) &&
               hand.Any(card => card.EndsWith("\u2666"));
    }

}
