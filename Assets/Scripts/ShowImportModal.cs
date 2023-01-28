using UnityEngine;
using UnityEngine.UI;

public class ShowImportModal : MonoBehaviour {
    public GameObject modal;
    public Button importButton;
    public Button cancel;

    public void Start() {
        importButton.onClick.AddListener(() => {
            modal.SetActive(true);
        });

        cancel.onClick.AddListener(() => {
            modal.SetActive(false);
        });
    }

}
