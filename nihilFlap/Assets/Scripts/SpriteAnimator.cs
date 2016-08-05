using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
public class SpriteAnimator : MonoBehaviour
{
    public AnimationClip[] animations;
    public Animator anim;
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
    public void Play(string animationName)
    {
        foreach(AnimationClip animation in animations)
        {
            if(animationName == animation.name)
                anim.Play(animation.name);
        }
        
    }
}
