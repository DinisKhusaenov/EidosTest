using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    [SerializeField] private CharacterRotation _player;
    [SerializeField] private ColorChanger _playerColor;
    [SerializeField] private CharacterReturn _characterReturn;
    [SerializeField] private Button _saveBtn;
    [SerializeField] private Button _loadBtn;
    [SerializeField] private Button _OnOffTrackingBtn;

    private string _filePath;

    private void Start()
    {
        _filePath = Application.persistentDataPath + "/save.gamesave";

        _saveBtn.onClick.AddListener(SaveGame);
        _loadBtn.onClick.AddListener(LoadGame);
        _OnOffTrackingBtn.onClick.AddListener(CharacterReturn);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
            SaveGame();

        if (Input.GetKey(KeyCode.L))
            LoadGame();

        if (Input.GetKey(KeyCode.O))
            CharacterReturn();
    }

    private void SaveGame()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_filePath, FileMode.Create);

        GameData gameData = new GameData();
        gameData.SaveRotation(_player);
        gameData.SaveColor(_playerColor);

        binaryFormatter.Serialize(fileStream, gameData);
        fileStream.Close();
    }

    private void LoadGame() 
    {
        if (!File.Exists(_filePath))
            return;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_filePath, FileMode.Open);

        GameData data = (GameData)binaryFormatter.Deserialize(fileStream);
        fileStream.Close();

        _player?.LoadRotatePosition(data.playerRotation);
        _playerColor?.LoadColor(data.playerColor);
    }

    private void CharacterReturn()
    {
        if (!File.Exists(_filePath))
            return;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_filePath, FileMode.Open);

        GameData data = (GameData)binaryFormatter.Deserialize(fileStream);
        fileStream.Close();

        _characterReturn.ReturnToSavePosition(data.playerRotation);
    }

    private void OnDestroy()
    {
        LoadGame();
    }
}
