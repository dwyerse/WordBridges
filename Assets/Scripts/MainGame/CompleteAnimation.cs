using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteAnimation : MonoBehaviour {
    public Manager manager;
    public GameObject levelComplete;


    public void StartAnimation() {
        for (int i = 0; i < manager.containers.Count; i++) {
            Transform container = manager.containers[i].transform;
            Transform letter = manager.letterObjects[i].transform;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(letter.DOScale(new Vector2(1.2f, 1.2f), 1.2f).SetEase(Ease.InOutQuad).SetDelay(0.2f));
            sequence.Append(letter.DOScale(new Vector2(0f, 0f), 0.5f).SetEase(Ease.InOutQuad));
            if (i == manager.containers.Count - 1) {
                sequence.Append(container.DOScale(new Vector2(0f, 0f), 0.3f).SetEase(Ease.InOutQuad)).OnComplete(LevelComplete);
            } else {
                sequence.Append(container.DOScale(new Vector2(0f, 0f), 0.3f).SetEase(Ease.InOutQuad));
            }
        }
    }

    void LevelComplete() {
        SceneManager.LoadScene("Levels");
    }

}
