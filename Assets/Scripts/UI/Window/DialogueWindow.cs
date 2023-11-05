using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueWindow : Window
{
    [SerializeField] private Character _interlocutor;
    [SerializeField] private Location _where;
    [SerializeField] private string _message;
    [SerializeField] private List<DialogueChoose> _chooses;
    [SerializeField] private int _id = -1;

    public Character Interlocuto => _interlocutor; 
    public Location Where => _where;
    public string Message => _message; 
    public IReadOnlyCollection<DialogueChoose> Chooses => _chooses;
    public int Id => _id;

    [CreateAssetMenu(menuName = "Data/Windows")]
    public class WindowsDataSet : ScriptableObject
    {
        [SerializeField] private List<DialogueWindow> _dialogues;
    }
}

[Serializable]
public class DialogueChoose
{
    [SerializeField] private string _message;
    [SerializeField] private int _targetWindow;

    public string Message => _message;
    public int TargetWindow => _targetWindow;
}