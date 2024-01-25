using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon Instance { get; private set; }

    public bool IsReloading = false;

    public int CurrentAmmo { get; private set; } = 5;

    private int _maxAmmo = 5;

    private float _reloadTime = 3f;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Instance = null;
        } else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (PlayerHidingController.IsPlayerHiding)
        {
            return;
        }

        if(IsReloading)
        {
            return;
        }

        if (CurrentAmmo == _maxAmmo)
        {
            return;
        }

        if (Input.GetAxis("Reload") != 0) 
        {
            ReloadWeapon();
        }
    }

    public bool Shoot()
    {
        if(CurrentAmmo > 0)
        {
            CurrentAmmo--;
            return true;
        }

        return false;
    }

    public void ReloadWeapon()
    {
        StartCoroutine(AddBullets());
    }

    private IEnumerator AddBullets()
    {
        IsReloading = true;

        while (CurrentAmmo < _maxAmmo)
        {
            yield return new WaitForSeconds(_reloadTime / _maxAmmo);
            CurrentAmmo++;
            Debug.Log("Reloading: " + CurrentAmmo);
        }

        IsReloading = false;
    }
}
