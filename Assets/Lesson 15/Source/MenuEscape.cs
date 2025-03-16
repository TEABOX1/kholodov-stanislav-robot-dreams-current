using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.MainSource;

public class MenuEscape : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    [SerializeField] private Button _confrimButton;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private string _lobbySceneName;
    [SerializeField] private InputControl _inputController;

    public bool Enabled
    {
        get => _canvas.enabled;
        set
        {
            if (_canvas.enabled == value)
                return;
            _canvas.enabled = value;
            _inputController.enabled = !value;

            Cursor.visible = value;
            Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    private void Awake()
    {
        _confrimButton.onClick.AddListener(ConfirmButtonHandler);
        _cancelButton.onClick.AddListener(CancelButtonHandler);
        Enabled = false;
    }

    private void Start()
    {
        InputControl.OnEscapeInput += EscapeHandler;
    }

    private void EscapeHandler()
    {
        Enabled = !Enabled;
    }

    private void ConfirmButtonHandler()
    {
        SceneManager.LoadSceneAsync(_lobbySceneName, LoadSceneMode.Single);
    }

    private void CancelButtonHandler()
    {
        Enabled = false;
    }
}
