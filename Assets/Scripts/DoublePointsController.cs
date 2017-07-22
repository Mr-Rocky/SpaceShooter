using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePointsController : MonoBehaviour {

    public int multiplicator;

    private GameController gameController;

    void Start () {
        gameController = this.GetComponentInParent<GameController>();

        gameController.IncreaseScoreMultiplicator(multiplicator);
	}
	
	void OnDestroy () {
        gameController.DecreaseScoreMultiplicator(multiplicator);
	}
}
