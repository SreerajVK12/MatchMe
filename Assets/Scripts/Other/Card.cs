using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Sprite Icon;
    public int CardIndex { get; private set; }

    public bool CardSelected;

    public Image Background;
    public Image MainSprite;
    public Image Overlay;

    private Button _button;

    private bool _bOnGameLoad;

    public bool IsMatchedCard { get; set; }

    private void Start()
    {
        _button = GetComponent<Button>();

        SetAplhaColorTo(Background.color, 1f);
        SetAplhaColorTo(MainSprite.color, 1f);
        SetAplhaColorTo(Overlay.color, 1f);

        _bOnGameLoad = true;

        if (IsMatchedCard)
        {
            PlayMatchCardAnimation();
        }
        else
        {
            Invoke("ShowCard", 0.5f);
            Invoke("HideCard", 1.5f);
        }
    }

    public void SetCardData(int iCardIndex, Sprite icon)
    {
        CardIndex = iCardIndex;
        Icon = icon;

        MainSprite.sprite = icon;
    }

    public void ButtonClicked()
    {
        if (!CardSelected)
        {
            GamePlayManager.Instance.OnCardButtonClick(this);
        }
    }

    #region Card Actions

    public void ShowCard()
    {
        CardSelected = true;

        PlayShowCardAnimation();
    }

    public void HideCard()
    {
        CardSelected = false;
        _button.enabled = true;

        Invoke("PlayHideCardAnimation", 0.5f);
    }

    public void DisableCard()
    {
        CardSelected = true;
        _button.enabled = false;

        Invoke("PlayMatchCardAnimation", 0.5f);
    }

    #endregion

    #region Animations  

    private void PlayShowCardAnimation()
    {
        StartCoroutine(ChangeColorCoroutine(1, 0));

        if (!_bOnGameLoad)
        {
            SoundManager.Instance.PlayOneShot(Sounds.CardFlip);
        }
    }

    private void PlayHideCardAnimation()
    {
        StartCoroutine(ChangeColorCoroutine(0, 1));

        if (!_bOnGameLoad)
        {
            SoundManager.Instance.PlayOneShot(Sounds.FlipFail);
        }

        _bOnGameLoad = false;
    }

    public void PlayMatchCardAnimation()
    {
        SoundManager.Instance.PlayOneShot(Sounds.FlipSucess);

        Background.color = new Color(Background.color.r, Background.color.g, Background.color.b, 0);
        MainSprite.color = new Color(MainSprite.color.r, MainSprite.color.g, MainSprite.color.b, 0);
        Overlay.color = new Color(Overlay.color.r, Overlay.color.g, Overlay.color.b, 0);

        IsMatchedCard = true;
    }

    private IEnumerator ChangeColorCoroutine(int iStartAlpha, int iEndAlpha)
    {
        Color startColor = Overlay.color;
        startColor.a = iStartAlpha;
        Color targetColor = Overlay.color;
        targetColor.a = iEndAlpha;

        float duration = 0.5f;
        float elapsedTime = 0f;

        // Gradually change color over the duration
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            Overlay.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);
            yield return null; // Wait for the next frame
        }

        // Ensure the color is exactly the target color at the end
        Overlay.color = targetColor;
    }

    private void SetAplhaColorTo(Color color, float alpha)
    {
        Color newColor = color;
        newColor.a = 1f;
    }

    #endregion
}
