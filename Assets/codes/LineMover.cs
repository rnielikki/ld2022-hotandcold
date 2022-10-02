using UnityEngine;

public class LineMover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    LineRenderer _renderer;
    [SerializeField]
    HingeJoint2D _joint;
    Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = _joint.connectedBody;
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.SetPosition(0, transform.position);
        _renderer.SetPosition(1, _rigidbody.transform.position);
    }
}
