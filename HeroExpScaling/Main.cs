using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(HeroExpScaling.Main), "Hero Exp Scaling", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace HeroExpScaling
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var tower in gameModel.towers)
            {
                if (tower.IsHero() && (tower.baseId.Contains("Ezili") || tower.baseId.Contains("PatFusty") || tower.baseId.Contains("AdmiralBrickell") || tower.baseId.Contains("Sauda")))
                {
                    if (tower.upgrades.Count > 0)
                    {
                        foreach (var upgrade in tower.upgrades)
                        {
                            var actualUpgrade = gameModel.GetUpgrade(upgrade.upgrade.ToString());
                            actualUpgrade.xpCost = (actualUpgrade.xpCost * 70175 / 100000); // x1.425 XP
                        }
                    }
                }
                if (tower.IsHero() && (tower.baseId.Contains("Benjamin") || tower.baseId.Contains("Psi")))
                {
                    if (tower.upgrades.Count > 0)
                    {
                        foreach (var upgrade in tower.upgrades)
                        {
                            var actualUpgrade = gameModel.GetUpgrade(upgrade.upgrade.ToString());
                            actualUpgrade.xpCost = (actualUpgrade.xpCost * 66667 / 100000); // x1.5 XP
                        }
                    }
                }
                if (tower.IsHero() && (tower.baseId.Contains("CaptainChurchill") || tower.baseId.Contains("Adora")))
                {
                    if (tower.upgrades.Count > 0)
                    {
                        foreach (var upgrade in tower.upgrades)
                        {
                            var actualUpgrade = gameModel.GetUpgrade(upgrade.upgrade.ToString());
                            actualUpgrade.xpCost = (actualUpgrade.xpCost * 58479 / 100000); // x1.71 XP
                        }
                    }
                }
            }
        }
    }
}