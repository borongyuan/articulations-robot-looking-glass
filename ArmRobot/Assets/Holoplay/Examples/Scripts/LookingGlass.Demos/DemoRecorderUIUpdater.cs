using UnityEngine;
using UnityEngine.UI;

namespace LookingGlass.Demos {
    public class DemoRecorderUIUpdater : MonoBehaviour {
        [SerializeField] private HoloplayRecorder recorder;

        [Header("Buttons")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button endButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;

        public HoloplayRecorder Recorder {
            get { return recorder; }
            private set {
                if (recorder != null)
                    recorder.onStateChanged -= UpdateButtonStates;

                recorder = value;

                if (recorder != null)
                    recorder.onStateChanged += UpdateButtonStates;

                UpdateButtonStates(recorder != null ? recorder.State : HoloplayRecorderState.NotRecording);
            }
        }

        private void Reset() {
            recorder = FindObjectOfType<HoloplayRecorder>();
        }

        private void OnEnable() {
            if (recorder == null)
                Debug.LogWarning(this + "'s recorder is not set! Unable to update UI.");

            Recorder = recorder;
        }

        private void OnDisable() {
            if (recorder != null)
                recorder.onStateChanged += UpdateButtonStates;
            UpdateButtonStates(HoloplayRecorderState.NotRecording);
        }

        private void UpdateButtonStates(HoloplayRecorderState state) {
            if (this == null || !isActiveAndEnabled)
                return;

            if (endButton != null)
                endButton.gameObject.SetActive(state == HoloplayRecorderState.Recording || state == HoloplayRecorderState.Paused);
            if (startButton != null)
                startButton.gameObject.SetActive(state == HoloplayRecorderState.NotRecording);
            if (pauseButton != null)
                pauseButton.gameObject.SetActive(state == HoloplayRecorderState.Recording);
            if (resumeButton != null)
                resumeButton.gameObject.SetActive(state == HoloplayRecorderState.Paused);
        }
    }
}
