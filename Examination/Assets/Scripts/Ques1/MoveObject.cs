using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Q1
{
    public class MoveObject : MonoBehaviour
    {
        public float speed = 1f;
        
        Rigidbody body;
        float init;
        
        void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        void Start()
        {
            StartCoroutine(Moving());
        }

        IEnumerator Moving()
        {
            init = transform.position.z;

            WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.05f);
            while (Mathf.Abs(transform.position.z - init) < 10)
            {
                transform.position += Vector3.forward * speed;

                wait.waitTime *= 0.9f;

                yield return wait;
            }
            body.velocity = Vector3.zero;
        }
    }
}
