using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

[System.Serializable]
public class FrameSwapperAnimation
{
    [SerializeField] string id = null;
    [SerializeField] Sprite[] sprites;
    [SerializeField] float animationSpeed = 0.1f;
    [SerializeField] bool loop = false;

    public int SpriteCount => sprites.Length;

    public Sprite GetSprite(int i_index)
    {
        return sprites[i_index];

    }

    public string GetId() { return id; }
    public float GetAnimationSpeed() { return animationSpeed; }
    public bool IsLoop() { return loop; }
}

public class CharacterAnimationController : MonoBehaviour
{
    //[SerializeField] ScriptableObjectTest soTest = null;
    [Header("Animations")]
    [SerializeField] FrameSwapperAnimation[] animations;

    //public Sprite[] walkingSprites;
    //public float animationSpeed = 0.1f;

    private SpriteRenderer spriteRenderer = null;
    //private CharacterController characterController;
    private int currentFrameIndex = 0;
    private float timeSinceLastFrame = 0f;
    private string currAnimID;


    private Dictionary<string, FrameSwapperAnimation> anims = null;
    private FrameSwapperAnimation currentAnimtion = null;

    private void Start()
    {
        anims = new Dictionary<string, FrameSwapperAnimation>();
        foreach (var anim in animations)
        {
            anims[anim.GetId()] = anim;
        }

    }

    public void StartAnimation(string id, SpriteRenderer spriteRenderer)
    {
        if (anims.ContainsKey(id))
        {
            this.spriteRenderer = spriteRenderer;
            currAnimID = id;
            currentAnimtion = anims[id];
            currentFrameIndex = 0;
            timeSinceLastFrame = 0f;
        }
    }
    public void StopAnimation(string id)
    {
        if (currAnimID == id)
        {
            currentAnimtion = null;
            currAnimID = null;
        }
    }


    private void Update()
    {
        if (currentAnimtion != null)
        {
            timeSinceLastFrame += Time.deltaTime;
            float currAnimSpeed = currentAnimtion.GetAnimationSpeed();
            if (timeSinceLastFrame >= currAnimSpeed)
            {
                timeSinceLastFrame -= currAnimSpeed;
                currentFrameIndex++;
                if (currentFrameIndex >= currentAnimtion.SpriteCount)
                {
                    if (currentAnimtion.IsLoop())
                    {
                        currentFrameIndex = 0;
                    }
                    else
                    {
                        currentAnimtion = null;
                        return;
                    }
                }
                Debug.Log($"currentAnimation: {currentAnimtion.GetSprite(0)}");
                Debug.Log($"currentFrameIndex: {currentFrameIndex}");
                spriteRenderer.sprite = currentAnimtion.GetSprite(currentFrameIndex);
            }
        }
    }
}