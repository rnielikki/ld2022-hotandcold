using System.Collections;
using UnityEngine;

namespace Assets.codes
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField]
        Transform _target;
        [SerializeField]
        Vector2 _offset;
        Vector3 _v3Offset;
        // Use this for initialization
        void Start()
        {
            var zPos = transform.position.z - _target.position.z;
            _v3Offset = _offset;
            _v3Offset.z = zPos;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = _target.transform.position + _v3Offset;
        }
    }
}