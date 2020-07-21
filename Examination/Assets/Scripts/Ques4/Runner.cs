using UnityEngine;

namespace Q4
{
    public class Runner : MonoBehaviour
    {
        GameManager manager;

        Animator anim;

        public delegate void Axis(float x, float y);
        public Axis player;

        public float speed
        {
            get
            {
                return anim.GetFloat("Move");
            }

            set {
                anim.SetFloat("Move", value);
                anim.SetBool("Moving", true);
            }
        }
        
        void Start()
        {
            anim = gameObject.GetComponent<Animator>();
            manager = FindObjectOfType<GameManager>();
            player += Run;
        }

        void Update()
        {
            transform.position += new Vector3(1, transform.position.y, 0) * Time.deltaTime * speed;
            player(2f, 0f);
        }


        public void Run(float x, float y)
        {
            speed = Mathf.Clamp(Mathf.Abs(x) + Mathf.Abs(y), 0, 2);
        }

        public void Stop(float x, float y)
        {
            speed = Mathf.Clamp(Mathf.Abs(x) + Mathf.Abs(y), 0, 2);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("point"))
            {
                player += Stop;
                player -= Run;
                manager.Finish();
            }
        }
    }
}
