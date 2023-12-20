using Unity.Mathematics;
using UnityEngine;
using V.Core;

public class LevelGenarateInteraction : InteractableBase
{
    [Header("Level Prefabs")]
    [SerializeField] private Transform jumpPad;

    [SerializeField] private float genarateYOffest;
    [SerializeField] private float minWidth;
    [SerializeField] private float maxWidth;

    public override void Interact()
    {
        float _randomX = UnityEngine.Random.Range(minWidth, maxWidth);
        Vector2 _genaratePosition = new Vector2(_randomX, transform.position.y);

        Instantiate(jumpPad, _genaratePosition, quaternion.identity);

        ChangeToNewPosition();
    }

    private void ChangeToNewPosition()
    {
        float _currentXPos = transform.position.x;

        gameObject.transform.position = new Vector2(_currentXPos, transform.position.y + genarateYOffest);
    }
}
