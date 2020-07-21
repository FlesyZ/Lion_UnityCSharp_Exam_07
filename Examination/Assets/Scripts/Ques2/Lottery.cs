using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Q2
{
    [ExecuteInEditMode]
    public class Lottery : MonoBehaviour
    {
        public Image item;
        public Button button;

        readonly List<Sprite> items = new List<Sprite>();
        bool isWorking = false;

        float timer;

        void Awake()
        {
            items.Clear();
            items.AddRange(Resources.LoadAll<Sprite>("RPG_inventory_icons"));

            item.sprite = items[Random.Range(0, items.Count)];
        }

        void Update()
        {
            if (timer > 0f)
                timer -= Time.deltaTime;
            else if (timer <= 0f && isWorking)
                isWorking = false;
        }
        
        public void Work()
        {
            timer = Random.Range(2f, 3f);
            isWorking = true;
            StartCoroutine(Working());
        }

        IEnumerator Working()
        {
            button.interactable = false;

            WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0f);
            while (isWorking)
            {
                item.sprite = items[Random.Range(0, items.Count)];
                wait.waitTime = 1 / (Mathf.Clamp(timer, 0.1f, timer) * 10);
                yield return wait;
            }

            button.interactable = true;
        }


    }
}
