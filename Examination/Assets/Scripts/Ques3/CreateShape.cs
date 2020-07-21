using System.Collections;
using UnityEngine;

namespace Q3
{
    public class CreateShape : MonoBehaviour
    {
        public GameObject cube;
        public int count = 5;

        Vector3 spawnPos = new Vector3();

        void Start()
        {
            StartCoroutine(Create());
        }

        IEnumerator Create()
        {
            WaitForSeconds wait = new WaitForSeconds(0.01f);
            for (float i = 0; i < count; i++)
            {
                for (float j = 0; j <= i; j++)
                {
                    spawnPos.x = (j - i / 2) * 0.5f;
                    spawnPos.y = i * 0.5f;
                    Instantiate(cube, spawnPos, Quaternion.identity, gameObject.transform);
                    yield return wait;
                }
            }
            for (float i = 0; i <= count; i++)
            {
                for (float j = count - i; j >= 0; j--)
                {
                    spawnPos.x = ((count - i) / 2 - j) * 0.5f;
                    spawnPos.y = (count + i) * 0.5f;
                    Instantiate(cube, spawnPos, Quaternion.identity, gameObject.transform);
                    yield return wait;
                }
            }
        }
    }
}