using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PackmanController : MonoBehaviour
{
    [SerializeField] private float _movementForce;

    private Vector2 _lastDirection;
    private Quaternion _lastRotation = MOVE_RIGHT_ANGLE;
    private Rigidbody2D _rigidbody;

    private static readonly Quaternion MOVE_UP_ANGLE = Quaternion.Euler(Vector3.forward * 90);
    private static readonly Quaternion MOVE_RIGHT_ANGLE = Quaternion.Euler(Vector3.forward * 0);
    private static readonly Quaternion MOVE_DOWN_ANGLE = Quaternion.Euler(Vector3.forward * 270);
    private static readonly Quaternion MOVE_LEFT_ANGLE = Quaternion.Euler(Vector3.forward * 180);

    private void Awake()
    {
		_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _lastDirection = Vector3.zero;
        _lastDirection.x = Input.GetAxis("Horizontal");
        _lastDirection.y = Input.GetAxis("Vertical");

        Quaternion newRot = _lastDirection switch
        {
            { x: > 0 } => MOVE_RIGHT_ANGLE,
            { x: < 0 } => MOVE_LEFT_ANGLE,
            { y: > 0 } => MOVE_UP_ANGLE,
            { y: < 0 } => MOVE_DOWN_ANGLE,
            _ => transform.rotation
        };

        if (!_lastRotation.Equals(newRot))
        {
            _rigidbody.velocity = Vector2.zero;
            _lastRotation = newRot;
            transform.rotation = _lastRotation;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _lastDirection.x != 0 ? Vector2.right * _lastDirection.x * _movementForce : Vector2.up * _lastDirection.y * _movementForce;
    }
}
