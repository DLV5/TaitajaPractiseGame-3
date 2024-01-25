using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental;
using UnityEngine;


public class LicenseOnAnimals : MonoBehaviour
{
    public static LicenseOnAnimals Instance;
    public event Action OnProhibitedAnimalShot;
    private List<AnimalType> _allAnimals = new List<AnimalType>();
    private List<AnimalType> _animalsWithLicense = new List<AnimalType>();

    private void Awake()
    {
        Instance = this;
        foreach (AnimalType animal in Enum.GetValues(typeof(AnimalType)))
        {
            _allAnimals.Add(animal);
        }
        GetRandomLicense();
    }

    /// <summary>
    /// Gives 2 random licenses to hunt animals
    /// </summary>
    private void GetRandomLicense()
    {
        for(int i = 0; i < 2;)
        {
            int index = UnityEngine.Random.Range(0, _allAnimals.Count);
            if (_animalsWithLicense.Contains(_allAnimals[index]))
                continue;
            else
            {
                _animalsWithLicense.Add(_allAnimals[index]);
                i++;
            }
        }
        ///////Testing DELETE////////
        Debug.Log(_animalsWithLicense.Count);
        foreach(AnimalType animal in _animalsWithLicense)
        {
            Debug.Log(animal.ToString());
        }
        ///////Testing DELETE////////
    }
    /// <summary>
    /// Checks whether shooting at an animal is allowed in the parameter
    /// </summary>
    /// <param name="animal"></param>
    /// <returns></returns>
    public bool IsShootingAllowed(AnimalType animal)
    {
        if (_animalsWithLicense.Contains(animal)){
            return true;
        }
        else
        {
            OnProhibitedAnimalShot?.Invoke();
            return false;
        }
    }
}
