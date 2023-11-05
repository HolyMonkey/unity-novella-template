using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueWindow : Window
{
    [SerializeField] private Character _interlocutor;
    [SerializeField] private Location _where;
    [SerializeField] private string _message;

    [SerializeField] private int _id = -1;

    public Character Interlocuto => _interlocutor; 
    public Location Where => _where;
    public string Message => _message; 

    //TODO: Not working
    [CreateAssetMenu(menuName = "Data/Windows")]
    public class WindowsDataSet : ScriptableObject
    {
        [SerializeField] private List<DialogueWindow> _dialogues;

        private int _lastId = 0;

        private void OnValidate()
        {
            foreach (var dialogue in _dialogues)
                if (dialogue._id == -1)
                    dialogue._id = ++_lastId;
        }
    }
}
