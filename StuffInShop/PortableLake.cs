﻿using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;

namespace BTD6_Portable_Lake_In_Shop
{
    public class PortableLake : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetPowerWithName("PortableLake").icon;
        public override SpriteReference IconReference => Game.instance.model.GetPowerWithName("PortableLake").icon;
        public override string TowerSet => SUPPORT;
        public override string BaseTower => TowerType.PortableLake;
        public override int Cost => 500;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Portable Lake";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        { }
    }
}