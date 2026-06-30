using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class skeletAnim : MonoBehaviour
{

	[SerializeField] private Animator _anim;

	[SerializeField] private GameObject _sphere;
	private const string _run = "run";


	private void Awake()
	{
		my_input_manger.OnSpacePressed += pupa67;
	}
	private void OnDisable()
	{
		my_input_manger.OnSpacePressed -= pupa67;
	}
	private void Start()
    {
        int random = Random.Range(0, 2);
	}
	private void pupa67()
	{
			_anim.SetTrigger("spin");
	}

	public void win()
	{
		_anim.SetTrigger("win");
	}
	public void run(bool runn)
	{
		_anim.SetBool(_run, runn);
	}
	public void spawnSphere()
	{
		Instantiate (_sphere, transform.position, transform.rotation);
	}
}
