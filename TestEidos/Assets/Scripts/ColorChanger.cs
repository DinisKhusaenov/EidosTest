using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material _eyeMaterial;
    [SerializeField] private Material _headMaterial;
    [SerializeField] private Material _bodyMaterial;
    [SerializeField] private Button _colorChangeBtn;
    [SerializeField] private Button _saveBtn;

    public Color EyeColor => _eyeMaterial.color;
    public Color HeadColor => _headMaterial.color;
    public Color BodyColor => _bodyMaterial.color;

    public void LoadColor(GameData.ColorSaveData colorData)
    {
        if (_eyeMaterial != null)
            _eyeMaterial.color = new Vector4(colorData.eyeColor.r, colorData.eyeColor.g, colorData.eyeColor.b, colorData.eyeColor.a);

        if (_headMaterial != null)
            _headMaterial.color = new Vector4(colorData.headColor.r, colorData.headColor.g, colorData.headColor.b, colorData.headColor.a);

        if (_bodyMaterial != null)
            _bodyMaterial.color = new Vector4(colorData.bodyColor.r, colorData.bodyColor.g, colorData.bodyColor.b, colorData.bodyColor.a);
    }

    private void Start()
    {
        _colorChangeBtn.onClick.AddListener(ChangeColor);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        if (_eyeMaterial != null)
            _eyeMaterial.color = Random.ColorHSV();

        if (_headMaterial != null)
            _headMaterial.color = Random.ColorHSV();

        if (_bodyMaterial != null)
            _bodyMaterial.color = Random.ColorHSV();
    }
}
