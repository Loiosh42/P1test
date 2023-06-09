﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace P1test.Items.Acsessories
{

	public class DaSHIELD : ModItem
	{

		public override void SetStaticDefaults() {
			Item.width = 26;
			Item.height = 32;
			DisplayName.SetDefault("Energy Shield");
			Tooltip.SetDefault("Bwahahah!!");
	
		}
		public override void SetDefaults() {

			Item.accessory = true; // Makes this item an accessory.
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(gold: 100); // Sets the item sell price to 100 gold coin.
		}

		public override void UpdateAccessory(Player p, bool hideVisual)
        {

            hideVisual = true;
			p.GetModPlayer<P1testPlayer>().ShieldActive = true; // for making more or adjusting shield items, adjust and use this stuff, code is in P1testPlayer
			p.GetModPlayer<P1testPlayer>().ShieldCooldownMax = 300; // int
			p.GetModPlayer<P1testPlayer>().ShieldMaxHP = 600; // double
			p.GetModPlayer<P1testPlayer>().ShieldResist = 0.75f; // float
			p.GetModPlayer<P1testPlayer>().ShieldRegen = 1; // double

		}

        





		public override void AddRecipes()
		{
			// because we don't call base.AddRecipes(), we erase the previously defined recipe and can now make a different one
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);

			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
