using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundOnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] List<Sprite> spritesTop;
    [SerializeField] List<Sprite> spritesBottom;
    [SerializeField] Image _background;
    [SerializeField] ParticleSystem _particleSystem;

    bool _isPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        changeBottom();
        _particleSystem.Play();
        AudioManager.instance.PlayRand();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed &= false;
        changeTop();
    }

    void changeTop()
    {
        int rand = Random.Range(0, spritesTop.Count);
        _background.sprite = spritesTop[rand];
    }
    void changeBottom()
    {
        int rand = Random.Range(0, spritesBottom.Count);
        _background.sprite = spritesBottom[rand];
    }

}
