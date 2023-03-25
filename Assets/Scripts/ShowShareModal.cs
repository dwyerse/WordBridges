using UnityEngine;
using UnityEngine.UI;

public class ShowShareModal : MonoBehaviour {
    public GameObject modal;
    public Button share;
    public Button copy;
    public Button cancel;
    public LevelEditor levelEditor;

    public void Start() {
        share.onClick.AddListener(() => {
            modal.SetActive(true);
            levelEditor.UpdateShareableString();
        });

        copy.onClick.AddListener(() => {
            GUIUtility.systemCopyBuffer = levelEditor.GetShareableString();
        });

        cancel.onClick.AddListener(() => {
            modal.SetActive(false);
        });
    }
}
