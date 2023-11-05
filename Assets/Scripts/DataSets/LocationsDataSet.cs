using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Locations")]
public class LocationsDataSet : ScriptableObject
{
    [SerializeField] private Sprite _kitchen;
    [SerializeField] private Sprite _entrance;

    public Sprite Get(Location location) =>
        location switch
        {
            Location.Kitchen => _kitchen,
            Location.Entrance => _entrance,
            _ => throw new NotImplementedException()
        };
}

public enum Location
{
    Kitchen,
    Entrance
}