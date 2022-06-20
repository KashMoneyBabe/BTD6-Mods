using Assets.Scripts.Models;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using BTD_Mod_Helper.Api.ModOptions;

[assembly: MelonInfo(typeof(DenserBloons.Main), "Denser Bloons", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace DenserBloons
{
    public class Main : BloonsTD6Mod
    {
        public static ModSettingBool enabled = new ModSettingBool(true)
        {
            displayName = "Enabled"
        };

        public static ModSettingInt multiplier = new ModSettingInt(4)
        {
            displayName = "Multiplier",
            minValue = 1,
            maxValue = 100,
            isSlider = false
        };

        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var roundSet in gameModel.roundSets)
            {
                for (int i = 0; i < roundSet.rounds.Count; i++)
                {
                    foreach (var group in roundSet.rounds[i].groups)
                    {
                        group.count *= multiplier;
                    }
                    roundSet.rounds[i] = new RoundModel("", roundSet.rounds[i].groups);
                }
            }
        }
    }
}