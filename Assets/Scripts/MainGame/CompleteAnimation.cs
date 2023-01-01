using UnityEngine;

public class CompleteAnimation : MonoBehaviour
{
    public Manager manager;
    public GameObject levelComplete;


    public void StartAnimation()
    {
        for (int i = 0; i < manager.containers.Count; i++)
        {
            LeanTween.scale(manager.letterObjects[i], new Vector2(1.2f, 1.2f), 1.2f).setEase(LeanTweenType.easeInOutQuad).setDelay(0.2f).setOnComplete(AnimationFinished).setOnCompleteParam(i);
        }
    }

    void AnimationFinished(object onCompleteParams)
    {
        int i = (int)onCompleteParams;
        LeanTween.scale(manager.letterObjects[i], new Vector2(0f, 0f), 0.5f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.scale(manager.containers[i], new Vector2(1.1f, 1.1f), 0.6f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(LetterAnimFinished).setOnCompleteParam(i);

    }

    void LetterAnimFinished(object onCompleteParams)
    {
        int i = (int)onCompleteParams;
        if (i == manager.containers.Count - 1)
        {
            LeanTween.scale(manager.containers[i], new Vector2(0f, 0f), 0.3f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(LevelComplete);
        }
        else
        {
            LeanTween.scale(manager.containers[i], new Vector2(0f, 0f), 0.3f).setEase(LeanTweenType.easeInOutQuad);
        }
    }

    void LevelComplete()
    {
        levelComplete.SetActive(true);
    }

}
