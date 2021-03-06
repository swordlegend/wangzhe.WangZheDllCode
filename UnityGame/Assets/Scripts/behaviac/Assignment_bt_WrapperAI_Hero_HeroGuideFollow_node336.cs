using Assets.Scripts.GameLogic;
using System;

namespace behaviac
{
	internal class Assignment_bt_WrapperAI_Hero_HeroGuideFollow_node336 : Assignment
	{
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int srchR = (int)pAgent.GetVariable(2451377514u);
			uint nearestEnemyWithoutNotInBattleJungleMonster = ((ObjAgent)pAgent).GetNearestEnemyWithoutNotInBattleJungleMonster(srchR);
			pAgent.SetVariable<uint>("p_targetID", nearestEnemyWithoutNotInBattleJungleMonster, 1128863647u);
			return result;
		}
	}
}
