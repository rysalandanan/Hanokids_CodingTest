using UnityEngine;

public class TapAction : MonoBehaviour
{
    //this script is for actions of the animal when tap by the player
    // Either they stay in place or move to another position
    // possibly revealing object behind it.\

    [Header("Is the animal moveable?: ")]
    [SerializeField] private bool isMovable;

    [Header("Egg's collider: ")]
    [SerializeField] private GameObject egg;

    private AnimalAction animalAction;
    private void Start()
    {
        animalAction = GetComponent<AnimalAction>();
        CheckNull();
    }

    private void OnMouseDown()
    {
        if(animalAction != null)
        {
            if (isMovable)
            {
                animalAction.StartMoving();
            }
            else
            {
                animalAction.StartStationaryAnimation();
            }
        }
        if(egg != null)
        {
            EnableEggCollider();
        }
    }
    private void EnableEggCollider()
    {
        CircleCollider2D eggCollider = egg.GetComponent<CircleCollider2D>();
        eggCollider.enabled = true;
    }
    private void CheckNull()
    {
        string error = "is not assigned or invalid on " + gameObject.name;

        if (animalAction == null)
        {
            Debug.LogError("Animal Movement" + error);
        }
        if (egg == null)
        {
            Debug.Log("Egg" + error);
        }
    }
}
