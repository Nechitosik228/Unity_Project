using UnityEngine;

public class player_controll : MonoBehaviour
{
	[SerializeField] private skeletAnim _anim_ctrl;
	private void Update()
	{

		if (Input.GetKeyDown(KeyCode.W))
		{
		_anim_ctrl.run(true);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
		_anim_ctrl.run(false);
		}



	}
}
