using System;
using UnityEngine;

public class CollectableHandler : MonoBehaviour
{
	[field:SerializeField] public int TotalScore {  get; private set; }
	public event Action<int> OnTotalScoreChanged;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Collectable collectable))
		{
			TotalScore += collectable.Score;
			OnTotalScoreChanged?.Invoke(TotalScore);
			Destroy(collision.gameObject);
		}
	}
}
