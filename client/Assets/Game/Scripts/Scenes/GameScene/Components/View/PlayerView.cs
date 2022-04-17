using UnityEngine;
using VortexGames.EngineCore;
using VortexGames.EngineCore.Base;
using VortexGames.Game.Scenes.GameScene.Components.Model.Actors;

namespace VortexGames.Game.Gameplay.Views
{
	public class PlayerView : ComponentBase, IView
	{
		private Player _player;

		void IView.Init()
		{
			_player = GetComponent<Player>();
		}

		void IView.Render()
		{
			
		}
	}
}
