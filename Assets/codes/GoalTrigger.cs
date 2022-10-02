using UnityEngine;

namespace Assets.codes
{
    public class GoalTrigger : MonoBehaviour
    {
        private LevelLoader _loader;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Init(LevelLoader loader)
        {
            _loader = loader;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_loader != null && collision.CompareTag("Player"))
            {
                _loader.ShowResult();
            }
        }
    }
}