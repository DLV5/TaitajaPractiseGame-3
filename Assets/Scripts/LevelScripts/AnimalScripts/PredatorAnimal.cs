using UnityEngine;
/// <summary>
/// Predators firslty trying to attack player and then running away
/// </summary>
public class PredatorAnimal : Animal
{
    public override void FinalAction()
    {
        Attack();
    }

    private void Attack()
    {
        Debug.Log("Tried to attack");
        RunAway();
    }
}
