using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;


namespace Docard.Cards
{
    class Juggernaut : CustomCard 
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            
            
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            int jugCount = data.currentCards.Count(x => x.cardName == "Juggernaut")+1;
            gunAmmo.maxAmmo         += jugCount;
            gun.damage              *= (float)(1 + (Math.Pow(2, jugCount - 1) * .1f));
            gun.reloadTime          *= (float)(1 + (Math.Pow(2, jugCount - 1) * .1f));
            gun.attackSpeed         *= (float)(1 + (Math.Pow(2, jugCount - 1) * .1f));
            gun.projectileSpeed     *= (float)(1 + (Math.Pow(2, jugCount - 1) * .1f));
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            int jugCount = data.currentCards.Count(x => x.cardName == "Juggernaut") + 1;
            gunAmmo.maxAmmo += jugCount;
            gun.damage *= (float)(1 + (Math.Pow(2, jugCount - 1) * .1f));
            gun.reloadTime *= (float)(1 + (Math.Pow(2, jugCount - 1) * .1f));
            gun.attackSpeed *= (float)(1 + (Math.Pow(2, jugCount - 1) * .1f));
            gun.projectileSpeed *= (float)(1 + (Math.Pow(2, jugCount - 1) * .1f));
        }


        protected override string GetTitle()
        {
            return "Juggernaut";
        }
        protected override string GetDescription()
        {
            return "Effects double every time you pick it up";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Ammo",
                    amount = "+1 base",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Damage",
                    amount = "+10% base",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bullet Speed",
                    amount = "+10% base",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Reload Speed",
                    amount = "+10% base",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Attack Speed",
                    amount = "+10% base",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return Docard.ModInitials;
        }
    }
}
