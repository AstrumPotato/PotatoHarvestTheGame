using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
	public float speed;

	public Animator animator;
	Vector3 direction;

	public void AnimateMovement(Vector3 direction)
	{
		if (animator != null)
		{
			if (direction.magnitude > 0)
			{
				animator.SetBool("isMoving", true);
				animator.SetFloat("horizontal", direction.x);
				animator.SetFloat("vertical", direction.y);
			}
			else
			{
				animator.SetBool("isMoving", false);
			}
		}
	}

	private void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal"); //czyta czy wciskamy a czy d
		float vertical = Input.GetAxisRaw("Vertical");//czyta w czy s

		direction = new Vector3(horizontal, vertical);

		AnimateMovement(direction);

	}

	private void FixedUpdate()
	{
		transform.position += direction * speed * Time.deltaTime; //time.deltatime ¿eby skalowa³ siê z fps
	}


}