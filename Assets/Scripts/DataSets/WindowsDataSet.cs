using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Windows")]
public class WindowsDataSet : ScriptableObject
{
    [SerializeField] private List<DialogueWindow> _dialogues;

    public IReadOnlyCollection<DialogueWindow> Windows => _dialogues;
}
