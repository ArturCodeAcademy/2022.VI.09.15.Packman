using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField, Min(0)] private float _maxDistance;
    [SerializeField, Min(0.1f)] private float _speed;
    [SerializeField] private AnimationCurve _clamping;

	private readonly Vector3 Z_POSITION = new(0, 0, -10);

    void LateUpdate()
    {
        float distance = Vector2.Distance(_target.position, transform.position);
        float eval = Mathf.Clamp01(distance / _maxDistance);

        distance -= _speed * Time.deltaTime * _clamping.Evaluate(eval);
        if (distance > _maxDistance)
            distance = _maxDistance;
        if (distance < 0)
            distance = 0;

        transform.position = Vector3.MoveTowards(transform.position, _target.position + Z_POSITION, _maxDistance - distance);
    }
}
