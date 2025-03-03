using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DebugUI : MonoBehaviour {
    [Header("UI References")]
    [SerializeField] private Transform debugMenuPanel;
    [SerializeField] private Button menuButton;
    
    [Header("UI Prefabs")]
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject separatorPrefab;
    
    [Header("Debug Settings")]
    [SerializeField] private KeyCode toggleKey = KeyCode.F1;
    [SerializeField] private KeyCode pauseKey = KeyCode.P;
    [SerializeField] private KeyCode reloadSceneKey = KeyCode.F5;

    // Store debug menu items and their actions
    private Dictionary<string, Action> debugActions = new Dictionary<string, Action>();
    
    private void Awake() {
        DontDestroyOnLoad(gameObject);
        
        // Set process mode to run even when game is paused
        if (menuButton != null) {
            menuButton.onClick.AddListener(ToggleMenu);
        }
        
        // Hide menu by default
        if (debugMenuPanel != null) {
            debugMenuPanel.gameObject.SetActive(false);
        }
        
        // Build initial debug menu
        BuildMenu();
    }

    private void Update() {
        // Toggle debug menu
        if (Input.GetKeyDown(toggleKey)) {
            ToggleMenu();
        }
        
        // Pause/unpause game
        if (Input.GetKeyDown(pauseKey)) {
            Time.timeScale = Time.timeScale > 0 ? 0 : 1;
            Debug.Log($"Game {(Time.timeScale > 0 ? "unpaused" : "paused")}");
        }
        
        // Reload current scene
        if (Input.GetKeyDown(reloadSceneKey)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    public void BuildMenu() {
        ClearMenu();
        
        // Time scale controls
        AddSeparator("Time Scale");
        AddMenuItem("Increase +", () => { Time.timeScale += 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Decrease -", () => { Time.timeScale -= 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Reset to 1.0", () => { Time.timeScale = 1.0f; Debug.Log("Time Scale reset to 1.0"); });
        
        AddSeparator("Time Scale");
        AddMenuItem("Increase +", () => { Time.timeScale += 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Decrease -", () => { Time.timeScale -= 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Reset to 1.0", () => { Time.timeScale = 1.0f; Debug.Log("Time Scale reset to 1.0"); });
        
        AddSeparator("Time Scale");
        AddMenuItem("Increase +", () => { Time.timeScale += 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Decrease -", () => { Time.timeScale -= 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Reset to 1.0", () => { Time.timeScale = 1.0f; Debug.Log("Time Scale reset to 1.0"); });
        
        AddSeparator("Time Scale");
        AddMenuItem("Increase +", () => { Time.timeScale += 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Decrease -", () => { Time.timeScale -= 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Reset to 1.0", () => { Time.timeScale = 1.0f; Debug.Log("Time Scale reset to 1.0"); });
        
        AddSeparator("Time Scale");
        AddMenuItem("Increase +", () => { Time.timeScale += 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Decrease -", () => { Time.timeScale -= 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Reset to 1.0", () => { Time.timeScale = 1.0f; Debug.Log("Time Scale reset to 1.0"); });
        
        AddSeparator("Time Scale");
        AddMenuItem("Increase +", () => { Time.timeScale += 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Decrease -", () => { Time.timeScale -= 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Reset to 1.0", () => { Time.timeScale = 1.0f; Debug.Log("Time Scale reset to 1.0"); });
        
        AddSeparator("Time Scale");
        AddMenuItem("Increase +", () => { Time.timeScale += 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Decrease -", () => { Time.timeScale -= 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Reset to 1.0", () => { Time.timeScale = 1.0f; Debug.Log("Time Scale reset to 1.0"); });
        
        AddSeparator("Time Scale");
        AddMenuItem("Increase +", () => { Time.timeScale += 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Decrease -", () => { Time.timeScale -= 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Reset to 1.0", () => { Time.timeScale = 1.0f; Debug.Log("Time Scale reset to 1.0"); });
        
        AddSeparator("Time Scale");
        AddMenuItem("Increase +", () => { Time.timeScale += 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Decrease -", () => { Time.timeScale -= 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Reset to 1.0", () => { Time.timeScale = 1.0f; Debug.Log("Time Scale reset to 1.0"); });
        
        AddSeparator("Time Scale");
        AddMenuItem("Increase +", () => { Time.timeScale += 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Decrease -", () => { Time.timeScale -= 0.3f; Debug.Log($"Time Scale: {Time.timeScale}"); });
        AddMenuItem("Reset to 1.0", () => { Time.timeScale = 1.0f; Debug.Log("Time Scale reset to 1.0"); });
        
        // Example Camera Shake (commented out, implement as needed)
        /*
        AddSeparator("Camera");
        AddMenuItem("Shake Light", () => CameraShaker.Instance?.ShakeCamera(0.5f, 0.1f));
        AddMenuItem("Shake Heavy", () => CameraShaker.Instance?.ShakeCamera(1.0f, 0.3f));
        */
        
        // Add custom game-specific debug options here
    }
    
    private void ClearMenu() {
        if (debugMenuPanel == null) return;
        
        foreach (Transform child in debugMenuPanel) {
            Destroy(child.gameObject);
        }
    }

    public void AddSeparator(string text = "") {
        if (debugMenuPanel == null || separatorPrefab == null) return;
        
        GameObject separator = Instantiate(separatorPrefab, debugMenuPanel);
        TextMeshProUGUI textComponent = separator.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null) {
            textComponent.text = text;
        }
    }

    public void AddMenuItem(string text, Action callback) {
        if (debugMenuPanel == null || buttonPrefab == null) return;
        
        GameObject buttonObj = Instantiate(buttonPrefab, debugMenuPanel);
        Button button = buttonObj.GetComponent<Button>();
        TextMeshProUGUI textComponent = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
        
        if (textComponent != null) {
            textComponent.text = text;
        }
        
        if (button != null) {
            button.onClick.AddListener(() => {
                callback?.Invoke();
                Debug.Log($"Executed: {text}");
            });
        }
        
        // debugActions[text] = callback;
    }
    
    public void ToggleMenu() {
        if (debugMenuPanel != null) {
            debugMenuPanel.gameObject.SetActive(!debugMenuPanel.gameObject.activeSelf);
        }
    }
}
