using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    private Animator animator;
    private static readonly int State = Animator.StringToHash("state");
    private enum CharacterState { idle, action, walk }

    private AnimalAction animalAction;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animalAction = GetComponent<AnimalAction>();
        CheckNull();
    }
    private void Update()
    {
        CharacterState state;
        if(animalAction.IsStationaryAnimationPlaying())
        {
            state = CharacterState.action;
        }
        else if (animalAction.IsMoving())
        {
            state = CharacterState.walk;
        }
        else
        {
            state = CharacterState.idle;
        }
        animator.SetInteger(State, (int)state);
    }
    private void CheckNull()
    {
        string error = "is not assigned or invalid on " + gameObject.name;

        if(animator == null)
        {
            Debug.LogError("Animator" + error);
        }
        if(animalAction == null)
        {
            Debug.LogError("Animal Action" + error);
        }
    }
}
