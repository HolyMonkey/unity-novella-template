using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueWindowView : MonoBehaviour
{
    [SerializeField] private Image _interlocutorView;
    [SerializeField] private Image _whereView;
    [SerializeField] private TextMeshProUGUI _messageView;

    public void Show(DialogueWindow window, CharactersDataSet characters, LocationsDataSet locations)
    {
        _interlocutorView.sprite = characters.Get(window.Interlocuto);
        _whereView.sprite = locations.Get(window.Where);
        _messageView.text = window.Message;
    }
}
