using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;
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
    }
}