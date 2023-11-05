using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Characters")]
public class CharactersDataSet : ScriptableObject
{
    [SerializeField] private Sprite _protagonist;
    [SerializeField] private Sprite _antagonist;

    public Sprite Get(Character character) =>
        character switch
        {
            Character.Protagonist => _protagonist,
            Character.Antagonist => _antagonist,
            _ => throw new NotImplementedException()
        };
}

public enum Character
{
    Protagonist,
    Antagonist
}