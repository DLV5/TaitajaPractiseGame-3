using UnityEngine;

/// <summary>
/// Spawns animals from different sides of a tree
/// </summary>
public class AnimalSpawner : MonoBehaviour
{
    //Positions relatively to tree
    [SerializeField] private Transform _leftPosition;
    [SerializeField] private Transform _rightPosition;

    //Can be replaced with child count
    private Animal _animalOnLeftPosition;
    private Animal _animalOnRightPosition;

    [SerializeField] private float _delayMinBetweenSpawn = 3f;
    [SerializeField] private float _delayMaxBetweenSpawn = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnAnimal", 2f, Random.Range(_delayMinBetweenSpawn, _delayMaxBetweenSpawn));
    }

    private void OnLefttAnimalEscaped()
    {
        _animalOnLeftPosition.OnAnimalEscaped -= OnLefttAnimalEscaped;
        _animalOnLeftPosition = null;
    }

    private void OnRightAnimalEscaped()
    {
        _animalOnRightPosition.OnAnimalEscaped -= OnRightAnimalEscaped;
        _animalOnRightPosition = null;
    }

    /// <summary>
    /// Spawn animals if there is awailable spots
    /// </summary>
    private void SpawnAnimal()
    {
        int index = Random.Range(0, ObjectPooler.SharedInstance.pooledObjectsList.Count);
        Animal animal = ObjectPooler.SharedInstance.GetPooledObject(index).GetComponent<Animal>();

        if(_animalOnLeftPosition == null)
        {
            SetAnimal(animal, _leftPosition.position);

            _animalOnLeftPosition = animal;
            _animalOnLeftPosition.OnAnimalEscaped += OnLefttAnimalEscaped;
        } else if (_animalOnRightPosition == null)
        {
            SetAnimal(animal, _rightPosition.position);

            _animalOnRightPosition = animal;
            _animalOnRightPosition.OnAnimalEscaped += OnRightAnimalEscaped;
        }
    }

    private void SetAnimal(Animal animalToSet, Vector3 positionToSpawn)
    {
        animalToSet.gameObject.transform.position = positionToSpawn;
        animalToSet.gameObject.SetActive(true);
        StartCoroutine(animalToSet.WaitUntilFinalAction());
    }
}
