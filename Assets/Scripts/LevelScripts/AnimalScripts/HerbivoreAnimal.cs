using UnityEngine;
/// <summary>
/// HerbivoreAnimals run away at the end and not attack
/// </summary>
public class HerbivoreAnimal : Animal
{
    public override void FinalAction()
    {
        Debug.Log("Running away");
        RunAway();
    }
}
