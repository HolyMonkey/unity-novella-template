using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WindowPresenter : MonoBehaviour
{
    [SerializeField] private DialogueWindowView WideScreen, TightScreen;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private CharactersDataSet _characters;
    [SerializeField] private LocationsDataSet _locations;
    [SerializeField] private WindowsDataSet _windows;

    [SerializeField] private Image _fader;

    private void Start()
    {
        Show(_windows.Windows.First());
    }

    public void Show(DialogueWindow dialogueWindow)
    {
        _fader.DOFade(1, 1f).OnComplete(() =>
            {
                TightScreen.gameObject.SetActive(false);
                WideScreen.gameObject.SetActive(false);

                DialogueWindowView view = GetView();
                view.Show(dialogueWindow, _characters, _locations, (choose) =>
                {
                    Show(_windows.Get(choose.TargetWindow));
                });
                view.gameObject.SetActive(true);

                _fader.DOFade(0, 1f);
            });
     }

    private DialogueWindowView GetView()
    {
        float aspectRatio = _canvas.renderingDisplaySize.x / _canvas.renderingDisplaySize.y;

        if (aspectRatio > 1f)
            return WideScreen;
        else
            return TightScreen;
    }
}
