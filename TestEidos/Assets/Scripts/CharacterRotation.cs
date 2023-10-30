using Unity.VisualScripting;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _leftEye;
    [SerializeField] private Transform _rightEye;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _body;
    [SerializeField] private float _rotationSpeed = 50f;

    private readonly float _maxEyeRotationAngle = 60f;
    private readonly float _maxHeadRotationAngle = 90f;

    public Transform Eye => _leftEye;
    public Transform Head => _head;
    public Transform Body => _body; 

    public void LoadRotatePosition(GameData.CharacterSaveDataRotation player)
    {
        _leftEye.rotation = Quaternion.Euler(player.eye.x, player.eye.y, player.eye.z);
        _rightEye.rotation = Quaternion.Euler(player.eye.x, player.eye.y, player.eye.z);
        _head.rotation = Quaternion.Euler(player.head.x, player.head.y, player.head.z);
        _body.rotation = Quaternion.Euler(player.body.x, player.body.y, player.body.z);
    }

    private void Update()
    {
        if (_target != null)
        {
            EyeRotation();
            HeadRotation();
            BodyRotation();
        }
    }

    private void EyeRotation()
    {
        var directionToTarget = _target.position - _leftEye.position;
        var eyeRotation = Quaternion.LookRotation(directionToTarget);
        _leftEye.rotation = Quaternion.RotateTowards(_leftEye.rotation, eyeRotation, _rotationSpeed * Time.deltaTime);
        _rightEye.rotation = Quaternion.RotateTowards(_rightEye.rotation, eyeRotation, _rotationSpeed * Time.deltaTime);
    }

    private void HeadRotation()
    {
        if (GetAngle(_leftEye.rotation, _head.rotation) >= _maxEyeRotationAngle)
        {
            var directionToTarget = _target.position - _head.position;
            var headRotation = Quaternion.LookRotation(directionToTarget);
            _head.rotation = Quaternion.RotateTowards(_head.rotation, headRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void BodyRotation()
    {
        if (GetAngle(_head.rotation, _body.rotation) >= _maxHeadRotationAngle)
        {
            var directionToTarget = _target.position - _body.position;
            var bodyRotation = Quaternion.LookRotation(directionToTarget);
            bodyRotation.x = _body.rotation.x;
            bodyRotation.z = _body.rotation.z;
            _body.rotation = Quaternion.RotateTowards(_body.rotation, bodyRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private static float GetAngle(Quaternion from, Quaternion to)
    {
        float angle = Quaternion.Angle(from, to);
        return angle;
    }
}
