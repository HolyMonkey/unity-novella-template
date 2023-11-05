using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;
using Unity.Mathematics;

public class DialogueWindowView : MonoBehaviour
{
    [SerializeField] private Image _interlocutorView;
    [SerializeField] private Image _whereView;
    [SerializeField] private Text _messageView;
    [SerializeField] private Transform _chooseButtonsContainer;

    //TODO: Говнокод
    public void Show(DialogueWindow window, CharactersDataSet characters, LocationsDataSet locations, UnityAction<DialogueChoose> onChoose)
    {
        _chooseButtonsContainer.gameObject.SetActive(false);
        foreach (Transform child in _chooseButtonsContainer)
            child.gameObject.SetActive(false);

        float talkAnimationDuration = window.Message.Length / 25F;
        _interlocutorView.rectTransform.SetLocalPositionAndRotation(new Vector3(-295.5f, -116.070007f, 0), quaternion.identity);
        _interlocutorView.sprite = characters.Get(window.Interlocuto);
        _interlocutorView.transform.DOKill();
        _interlocutorView.transform.DOShakePosition(talkAnimationDuration, 2, 3, fadeOut: false).SetEase(Ease.OutElastic);
        _whereView.sprite = locations.Get(window.Where);
        _messageView.DOKill();
        _messageView.text = " ";
        _messageView.DOText(window.Message, talkAnimationDuration).SetEase(Ease.Linear);
        int i = 0;
        foreach (var choose in window.Chooses)
        {
            Button chooseButton = _chooseButtonsContainer.GetChild(i++).GetComponent<Button>();
            Text text = chooseButton.GetComponentInChildren<Text>();

            chooseButton.onClick.AddListener(() =>
            {
                onChoose?.Invoke(choose);
            });
            text.text = choose.Message;
            chooseButton.gameObject.SetActive(true);
        }

        if (i > 0)
        {
            _chooseButtonsContainer.gameObject.SetActive(true);
        }
    }
}
