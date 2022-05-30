using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(HeroExpBoost.Main), "Hero Exp Boost", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace HeroExpBoost
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var tower in gameModel.towers)
            {
                if (tower.IsHero())
                {
                    if (tower.upgrades.Count > 0)
                    {
                        foreach (var upgrade in tower.upgrades)
                        {
                            var actualUpgrade = gameModel.GetUpgrade(upgrade.upgrade.ToString());
                            actualUpgrade.xpCost = (actualUpgrade.xpCost * 50 / 100); // 2x faster hero leveling for all heroes
                        }
                    }
                }
            }
        }
    }
}