﻿namespace Midnight.Engine.Core
{
	public enum Status
	{
		Success,
		Idle,

		NotTurnOfSource,
		NotAtReserve,
		PointsAreUsed,
		CellIsNotAllowed,
		NoMovementAbility,
		NoDeploymentAbility,
		NoAttackAbility,
		FightRoundIsEmpty,
		NoCounterAttackAbility,
		AbilityIsUsed,
		NotAtBattlefield,
		TargetIsFriendly,
		TargetIsTooFar,
		NotAtForefront,
		TargetIsDead,
		CardHasLives,
		TargetIsUnderCamouflage
	}
}
