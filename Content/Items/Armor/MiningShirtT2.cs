using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


namespace AdditionalMiningSets.Content.Items.Armor {

    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Body)]
    public class MiningShirtT2 : ModItem {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.AdditionalMiningSets.hjson file.

        // todo - the following two thingos, probably through the hjson file
        //public static readonly float miningSpeedIncrease = 0.1f;
        //public override LocalizedText tooltip = base.tooltip.WithFormatArgs(miningSpeedIncrease);

        public override void SetDefaults() {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(0, 1, 0, 0); // How many coins the item is worth (platinum, gold, silver, copper)
            Item.rare = ItemRarityID.LightRed; // The rarity of the item
            Item.defense = 6; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player) {
            player.pickSpeed -= 0.1f;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.MiningShirt)
                .AddIngredient(ItemID.Granite, 20)
                .AddIngredient(ItemID.Silk, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
