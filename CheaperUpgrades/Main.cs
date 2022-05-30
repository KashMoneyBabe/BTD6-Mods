using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(CheaperUpgrades.Main), "Cheaper Upgrades", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace CheaperUpgrades
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {

            foreach (var towerModel in gameModel.towers)
            {
                towerModel.cost = (towerModel.cost * 90 / 100) - (towerModel.cost * 90 / 100) % 5;
            }

            foreach (var upgradeModel in gameModel.upgrades)
            {
                if (upgradeModel.tier == 4)
                {
                    upgradeModel.cost = (upgradeModel.cost * 70 / 100) - (upgradeModel.cost * 70 / 100) % 5;
                }
                if (upgradeModel.tier == 3)
                {
                    upgradeModel.cost = (upgradeModel.cost * 90 / 100) - (upgradeModel.cost * 90 / 100) % 5;
                }
                if (upgradeModel.tier == 2)
                {
                    upgradeModel.cost = (upgradeModel.cost * 90 / 100) - (upgradeModel.cost * 90 / 100) % 5;
                }
                if (upgradeModel.tier == 1)
                {
                    upgradeModel.cost = (upgradeModel.cost * 90 / 100) - (upgradeModel.cost * 90 / 100) % 5;
                }
                if (upgradeModel.tier == 0)
                {
                    upgradeModel.cost = (upgradeModel.cost * 90 / 100) - (upgradeModel.cost * 90 / 100) % 5;
                }
            }
        }
    }
}
