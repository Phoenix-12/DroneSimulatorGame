using UnityEngine;

public interface IControllable
{
	void Move(Vector3 direction);
	void Jump();
	void Attack(Vector3 direction);
	void ADS();
}