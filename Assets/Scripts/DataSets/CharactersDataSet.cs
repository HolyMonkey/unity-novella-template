using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Characters")]
public class CharactersDataSet : ScriptableObject
{
    [SerializeField] private Sprite _cj;
    [SerializeField] private Sprite _bigSmoke;
    [SerializeField] private Sprite _bigSmokeShoots;
    [SerializeField] private Sprite _narcoDiller;
    [SerializeField] private Sprite _sweet;
    [SerializeField] private Sprite _policeman;

    public Sprite Get(Character character) =>
        character switch
        {
            Character.Policeman => _policeman,
            Character.Sweet => _sweet,
            Character.BigSmoke => _bigSmoke,
            Character.CJ => _cj,
            Character.NarcoDiller => _narcoDiller,
            Character.BigSmokeShoots => _bigSmokeShoots,
            _ => throw new NotImplementedException()
        };
}

public enum Character
{
    CJ,
    BigSmoke,
    BigSmokeShoots,
    Sweet,
    NarcoDiller,
    Policeman
}