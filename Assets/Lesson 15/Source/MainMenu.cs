using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private string _gameSceneName;
    private void Awake()
    {
        _startButton.onClick.AddListener(TrainingRangeButtonHandler);
        _exitButton.onClick.AddListener(QuitButtonHandler);
    }
    private void TrainingRangeButtonHandler()
    {
        SceneManager.LoadSceneAsync(_gameSceneName, LoadSceneMode.Single);
    }

    private void QuitButtonHandler()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}