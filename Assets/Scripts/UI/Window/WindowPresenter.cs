using System.Linq;
using UnityEngine;

public class WindowPresenter : MonoBehaviour
{
    [SerializeField] private DialogueWindowView WideScreen, TightScreen;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private CharactersDataSet _characters; 
    [SerializeField] private LocationsDataSet _locations; 
    [SerializeField] private WindowsDataSet _windows; 
    
    private void Start()
    {
        Show(_windows.Windows.First());
    }

    public void Show(DialogueWindow dialogueWindow)
    {
        TightScreen.gameObject.SetActive(false);
        WideScreen.gameObject.SetActive(false);

        DialogueWindowView view = GetView();
        view.Show(dialogueWindow, _characters, _locations);
        view.gameObject.SetActive(true);
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