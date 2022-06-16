using BTD_Mod_Helper;
using MelonLoader;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using Il2CppSystem.Collections.Generic;
using Assets.Scripts.Models.Towers.Behaviors;
using BTD_Mod_Helper.Extensions;
using Main = StuffInShop.Main;

[assembly: MelonInfo(typeof(Main), "Stuff In Shop", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace StuffInShop
{
    public class Main : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            LoggerInstance.Msg("Stuff In Shop mod loaded");
        }

        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.towers)
            {
                if (towerModel.baseId == "StuffInShop-LivesFarmer")
                {
                    var bonusLives = new BonusLivesPerRoundModel("BonusLivesPerRoundModel_" + towerModel.baseId, 1, 1.25f, "eb70b6823aec0644c81f873e94cb26cc");
                    towerModel.AddBehavior(bonusLives);
                }
            }
        }
    }
}