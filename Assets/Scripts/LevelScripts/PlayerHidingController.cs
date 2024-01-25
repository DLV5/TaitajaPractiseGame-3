using UnityEngine;

/// <summary>
/// Controls player hiding state
/// </summary>
public class PlayerHidingController : MonoBehaviour
{
    public static bool IsPlayerHiding { get; private set; }

    [SerializeField] private GameObject _hidingUI;

    private void Update()
    {
        if (Input.GetAxis("Hide") != 0)
        {
            IsPlayerHiding = true;
            _hidingUI.SetActive(true);
        } else
        {
            IsPlayerHiding = false;
            _hidingUI.SetActive(false);
        }
    }
}
