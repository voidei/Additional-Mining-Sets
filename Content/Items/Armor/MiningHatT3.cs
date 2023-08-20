using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


namespace AdditionalMiningSets.Content.Items.Armor {

    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class MiningHatT3 : ModItem {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.AdditionalMiningSets.hjson file.

        public override void SetStaticDefaults() {
            // If your head equipment should draw hair while drawn, use one of the following:
            // ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
            // ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
            // ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
            // ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true; 
        }

        public override void SetDefaults() {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(0, 1, 0, 0); // How many coins the item is worth (platinum, gold, silver, copper)
            Item.rare = ItemRarityID.Yellow; // The rarity of the item
            Item.defense = 14; // The amount of defense the item will give when equipped
        }


        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs) =>
            body.type == ModContent.ItemType<MiningShirtT3>() && legs.type == ModContent.ItemType<MiningPantsT3>();

        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player) {
            // todo
            player.setBonus = Language.GetTextValue("Mods.AdditionalMiningSets.SetBonus.MiningSet");
            player.pickSpeed -= 0.1f; // Increases mining speed by 10%
        }

        public override void UpdateEquip(Player player)
        {
            player.nightVision = true;
            //player.AddBuff(BuffID.Shine, 2, true);

            Lighting.AddLight(player.Center, 1.0f, 1.0f, 1.0f);
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes() {

            // potential second recipe, for if you don't have it or don't wanna grind it
            CreateRecipe()
                .AddIngredient<MiningHatT2>()
                .AddIngredient(ItemID.ShroomiteBar, 6)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
