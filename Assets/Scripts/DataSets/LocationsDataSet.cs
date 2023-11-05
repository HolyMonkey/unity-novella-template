using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Locations")]
public class LocationsDataSet : ScriptableObject
{
    [SerializeField] private Sprite _laneWithBike;
    [SerializeField] private Sprite _groveStreet;
    [SerializeField] private Sprite _home;
    [SerializeField] private Sprite _gettho;

    public Sprite Get(Location location) =>
        location switch
        {
            Location.LaneWithBike => _laneWithBike,
            Location.GroveStreet => _groveStreet,
            Location.Home => _home,
            Location.Gettho => _gettho,
            _ => throw new NotImplementedException()
        };
}

public enum Location
{
    LaneWithBike,
    GroveStreet,
    Home,
    Gettho,
}