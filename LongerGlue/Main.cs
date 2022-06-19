using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(LongerGlue.Main), "Longer Glue", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace LongerGlue
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.GlueGunner))
            {
                if (towerModel.GetWeapon().projectile.HasBehavior<SlowModel>())
                {
                    var slow = towerModel.GetWeapon().projectile.GetBehavior<SlowModel>();
                    slow.lifespanFrames += 18000 * (towerModel.appliedUpgrades.Count + 1);
                }
            }
        }
    }
}