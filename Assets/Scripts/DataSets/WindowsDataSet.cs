using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Windows")]
public class WindowsDataSet : ScriptableObject
{
    [SerializeField] private List<DialogueWindow> _dialogues;

    public IReadOnlyCollection<DialogueWindow> Windows => _dialogues;

    internal DialogueWindow Get(int targetWindow)
    {
        return _dialogues.Find(dialogue => dialogue.Id == targetWindow);
    }
}
