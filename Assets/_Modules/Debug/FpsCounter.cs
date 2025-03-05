using TMPro;
using UnityEngine;
using Utilities;

public class FpsCounter : MonoBehaviour {
    [SerializeField] private float updateInterval = 2.0f;
    private TextMeshProUGUI fpsText;

    private CountdownTimer countdownTimer;

    private void Awake() {
        fpsText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        countdownTimer = new CountdownTimer(updateInterval);

        countdownTimer.OnTimerStop += () => {
            UpdateFpsText();
            countdownTimer.Start();
        };

        countdownTimer.Start();
        UpdateFpsText();
    }

    private void Update() {
        countdownTimer.Tick(Time.deltaTime);
    }

    private void UpdateFpsText() {
        fpsText.text = $"FPS: {(int) (1.0f / Time.deltaTime)}";
    }
}
