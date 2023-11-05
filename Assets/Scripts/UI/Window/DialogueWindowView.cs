using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;

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

        float talkAnimationDuration = window.Message.Length / 25;

        _interlocutorView.sprite = characters.Get(window.Interlocuto);
        _interlocutorView.transform.DOShakePosition(talkAnimationDuration, 2, 3, fadeOut: false).SetEase(Ease.OutElastic);
        _whereView.sprite = locations.Get(window.Where);
        _messageView.text = "";
        _messageView.DOText(window.Message, talkAnimationDuration).SetEase(Ease.Linear).OnComplete(() =>
        {            
            int i = 0;
            foreach (var choose in window.Chooses)
            {
                Button chooseButton = _chooseButtonsContainer.GetChild(i++).GetComponent<Button>();
                Text text = chooseButton.GetComponentInChildren<Text>();

                chooseButton.onClick.AddListener(() => onChoose?.Invoke(choose));
                text.text = choose.Message;
                chooseButton.gameObject.SetActive(true);

                chooseButton.GetComponent<Image>().DOFade(0, 0f).OnComplete(() =>
                {
                    chooseButton.GetComponent<Image>().DOFade(1, 1f);
                });
            }

            if (i > 0)
            {
                _chooseButtonsContainer.gameObject.SetActive(true);
                _chooseButtonsContainer.GetComponent<Image>().DOFade(0, 0f).OnComplete(() =>
                {
                    _chooseButtonsContainer.GetComponent<Image>().DOFade(1, 1f);
                });
            }
        });
    }
}
