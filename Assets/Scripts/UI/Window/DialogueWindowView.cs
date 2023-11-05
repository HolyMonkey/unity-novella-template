using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DialogueWindowView : MonoBehaviour
{
    [SerializeField] private Image _interlocutorView;
    [SerializeField] private Image _whereView;
    [SerializeField] private TextMeshProUGUI _messageView;
    [SerializeField] private Transform _chooseButtonsContainer;

    //TODO: Говнокод
    public void Show(DialogueWindow window, CharactersDataSet characters, LocationsDataSet locations, UnityAction<DialogueChoose> onChoose)
    { 
        _interlocutorView.sprite = characters.Get(window.Interlocuto);
        _whereView.sprite = locations.Get(window.Where);
        _messageView.text = window.Message;

        foreach (Transform child in _chooseButtonsContainer)
            child.gameObject.SetActive(false);

        int i = 0;
        foreach (var choose in window.Chooses)
        {
            Button chooseButton = _chooseButtonsContainer.GetChild(i++).GetComponent<Button>();
            chooseButton.GetComponentInChildren<Text>().text = choose.Message;
            chooseButton.onClick.AddListener(() => onChoose?.Invoke(choose));
            chooseButton.gameObject.SetActive(true);
        }
    }
}
