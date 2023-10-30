using UnityEngine;

[RequireComponent(typeof(CharacterRotation))]
public class CharacterReturn : MonoBehaviour
{
    [SerializeField] private Transform _leftEye;
    [SerializeField] private Transform _rightEye;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _body;

    private float _rotationSpeed;
    private bool _trackingIsActive = true;
    private Quaternion _eyeRotation;
    private Quaternion _headRotation;
    private Quaternion _bodyRotation;

    private void Start()
    {
        _rotationSpeed = GetComponent<CharacterRotation>().RotationSpeed;
    }

    public void ReturnToSavePosition(GameData.CharacterSaveDataRotation saveRotation)
    {
        if (_trackingIsActive)
        {
            _trackingIsActive = false;
            GetComponent<CharacterRotation>().enabled = false;

            _eyeRotation = new Quaternion(saveRotation.eye.x, saveRotation.eye.y, saveRotation.eye.z, 0);
            _headRotation = new Quaternion(saveRotation.head.x, saveRotation.head.y, saveRotation.head.z, 0);
            _bodyRotation = new Quaternion(saveRotation.body.x, saveRotation.body.y, saveRotation.body.z, 0);
        }
        else
        {
            _trackingIsActive = true;
            GetComponent<CharacterRotation>().enabled = true;
        }
    }

    private void Update()
    {
        if (!_trackingIsActive)
        {
            EyeRotation(_eyeRotation);
            HeadRotation(_headRotation);
            BodyRotation(_bodyRotation);
        }
    }

    private void EyeRotation(Quaternion eyeRotation)
    {
        _leftEye.rotation = Quaternion.RotateTowards(_leftEye.rotation, eyeRotation, _rotationSpeed * Time.deltaTime);
        _rightEye.rotation = Quaternion.RotateTowards(_rightEye.rotation, eyeRotation, _rotationSpeed * Time.deltaTime);
    }

    private void HeadRotation(Quaternion headRotation)
    {
        _head.rotation = Quaternion.RotateTowards(_head.rotation, headRotation, _rotationSpeed * Time.deltaTime);
    }

    private void BodyRotation(Quaternion bodyRotation)
    {
        _body.rotation = Quaternion.RotateTowards(_body.rotation, bodyRotation, _rotationSpeed * Time.deltaTime);
    }
}
