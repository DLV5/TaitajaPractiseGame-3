using UnityEngine;
/// <summary>
/// Predators firslty trying to attack player and then running away
/// </summary>
public class PredatorAnimal : Animal
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void FinalAction()
    {
        Attack();
    }

    private void Attack()
    {
        if(!PlayerHidingController.IsPlayerHiding)
        {
            _animator.SetTrigger("AttackedSuccessfully");
            //Show lose screen
        } else
        {
            Debug.Log(!PlayerHidingController.IsPlayerHiding + "Attack failed");
            RunAway();
        }
    }
}
