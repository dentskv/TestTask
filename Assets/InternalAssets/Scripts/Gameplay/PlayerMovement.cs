using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 _direction;
    private float _speed = 1.2f;
    private float _horizontal;
    private float _vertical;

    private float _angle;
    private float _radius = 4f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _angle += Time.fixedDeltaTime;

        _animator.SetFloat("Speed", Vector3.ClampMagnitude(_direction, 1).magnitude);
            
        var x = Mathf.Cos(_angle) * _radius;
        var z = Mathf.Sin(_angle) * _radius;
        _direction = new Vector3(x, 0, z);
            
        if(_direction.magnitude > 0.1f) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_direction), Time.fixedDeltaTime * 10);
            
        _rigidbody.velocity = _direction * _speed;
    }
}
