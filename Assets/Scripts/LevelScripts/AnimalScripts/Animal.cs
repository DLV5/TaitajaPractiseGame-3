using System;
using System.Collections;
using UnityEngine;

public enum AnimalType
{
    Rabbit,
    Deer,
    Bear,
    Wolf
}

/// <summary>
/// The base class of all animals
/// </summary>
public class Animal : MonoBehaviour
{
    public event Action OnAnimalEscaped;

    [field: SerializeField] public AnimalType Type { get; set; }
    protected float _timeUntilFinalAction = 8f;

    public virtual void FinalAction() 
    {
        Debug.Log("BasicAnimalAction");
    }

    protected void RunAway()
    {
        gameObject.SetActive(false);
        OnAnimalEscaped?.Invoke();
    }

    public IEnumerator WaitUntilFinalAction()
    {
        yield return new WaitForSeconds(_timeUntilFinalAction);
        FinalAction();
    }

    private void OnMouseDown()
    {
        if (Weapon.Instance.IsReloading)
        {
            return;
        }

        if (Weapon.Instance.Shoot())
        {
            Debug.Log("Shooted " +  Weapon.Instance.CurrentAmmo);
            RunAway();
        } else
        {
            Debug.Log("Not enough ammo");
        }
    }
}
