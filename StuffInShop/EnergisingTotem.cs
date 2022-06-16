using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;

namespace BTD6_Energising_Totem_In_Shop
{
    public class EnergisingTotem : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetPowerWithName("EnergisingTotem").icon;
        public override SpriteReference IconReference => Game.instance.model.GetPowerWithName("EnergisingTotem").icon;
        public override string TowerSet => MAGIC;
        public override string BaseTower => TowerType.EnergisingTotem;
        public override int Cost => 4000;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Energising Totem";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        { }
    }
}