using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Q5
{
    public class Cards : MonoBehaviour
    {
        public Button button;

        public List<GameObject> cards = new List<GameObject>();

        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.05f);
        
        void Awake()
        {
            wait.waitTime = 0.05f;

            cards.Clear();

            int num, shape;
            for (int i = 0; i < 52; i++)
            {
                string cardName = "";
                num = i % 13 + 1;
                shape = i / 13;

                switch (num)
                {
                    case 1:
                        cardName += "A";
                        break;
                    case 11:
                        cardName += "J";
                        break;
                    case 12:
                        cardName += "Q";
                        break;
                    case 13:
                        cardName += "K";
                        break;
                    default:
                        cardName += num;
                        break;
                }

                switch (shape)
                {
                    case 0:
                        cardName += "Diamond";
                        break;
                    case 1:
                        cardName += "Club";
                        break;
                    case 2:
                        cardName += "Heart";
                        break;
                    case 3:
                        cardName += "Spades";
                        break;
                }

                cards.Add(Resources.Load<GameObject>("Free_Playing_Cards/PlayingCards_" + cardName));
            }
        }

        IEnumerator Start()
        {
            Vector3 spawnPos = new Vector3();
            for (int i = 0; i < cards.Count; i++)
            {
                spawnPos.x = i % 13 * 0.75f - 4.5f;
                spawnPos.y = 2 - i / 13;

                Instantiate(cards[i], spawnPos * 0.1f, Quaternion.Euler(0, 180, 0), gameObject.transform);
                yield return wait;
            }

            button.interactable = true;
        }

        IEnumerator ClearCards(bool[] cards)
        {
            button.interactable = false;

            wait.waitTime = 0.01f;
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                if (cards[i])
                    Destroy(transform.GetChild(i).gameObject);
                yield return wait;
            }
        }

        public void ClearEvenCards()
        {
            bool[] clear = new bool[transform.childCount];
            
            for (int n = 0; n < transform.childCount; n++)
            {
                for (int i = 1; i <= 6; i++)
                {
                    string num = (i == 6) ? "Q" : (i * 2).ToString();
                    if (transform.GetChild(n).gameObject.name.Contains(num))
                    {
                        clear[n] = true;
                        break;
                    }
                }
            }

            StartCoroutine(ClearCards(clear));
        }
    }
}
