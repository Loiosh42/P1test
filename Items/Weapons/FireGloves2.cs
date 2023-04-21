using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace P1test.Items.Weapons
{
	public class FireGloves2 : ModItem
	{
		public int a = 1;
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Kung-Fu + Fire-Balls");
		}
		
		public override void SetDefaults() {

			Item.CloneDefaults(ItemID.Arkhalis);
			Item.damage = 200;
			
			//item.melee = true;
			//item.ranged = true;
			Item.width = 100;
			Item.height = 100;
			Item.useTime = 16;
			Item.useAnimation = 20;
			//item.useStyle = 5; // how you use the item (swinging, holding out, etc)
			Item.knockBack = 10;
			//item.value = 10000;
			//item.rare = ItemRarityID.Green;
			//item.UseSound = SoundID.Item1;
			Item.autoReuse = true;






		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		public override bool AltFunctionUse(Player player) {
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 0);
		}
		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				/*if(player.GetModPlayer<P1testPlayer>().Scarfe = true/* || player.GetModPlayer<P1testPlayer>().Scarf = true)
                {
					item.useTime = 4;
					item.useAnimation = 20;
					item.shoot = 85;
					item.useStyle = 5;
					item.shootSpeed = 4f;
					//item.hidevisual = true;
				}
                else*/
                //{
					Item.useStyle = ItemUseStyleID.Shoot; // how you use the item (swinging, holding out, etc)
					Item.useTime = 35;
					Item.useAnimation = 35;
					Item.damage = 500;
					Item.shoot = 34;
					Item.shootSpeed = 4f;
				//}
				
			}
			else {
				Item.CloneDefaults(ItemID.Arkhalis);
				//if (a % 5 == 1 || a % 5 == 2|| a % 5 == 3 || a % 5 == 4)
				//{
				//	item.shoot = 595;
				//	item.shootSpeed = 2.5f;
				//}
				//
				//else if (a % 5 == 0)
				//{
				//	item.shoot = 684;
				//	item.shootSpeed = 2.5f;
				//}
				
			}
			return base.CanUseItem(player);
		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			if (player.altFunctionUse == 2) {
				target.AddBuff(BuffID.OnFire, 360);
				target.AddBuff(323, 360);
				target.AddBuff(39, 360);
			}
			else {
				target.AddBuff(BuffID.Ichor, 120);
				player.AddBuff(2, 360);
				player.AddBuff(115, 360);
			}
			//a = a + 1;
		}

		/*public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3)) {
				if (player.altFunctionUse == 2) {
					int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 169, 0f, 0f, 100, default(Color), 2f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity.X += player.direction * 2f;
					Main.dust[dust].velocity.Y += 0.2f;
				}
				else {
					int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
					Main.dust[dust].noGravity = true;
				}
			}
		}*/

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			if (player.altFunctionUse == 2)
			{
				Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, Mod.Find<ModProjectile>("InvisBuff3").Type, damage, knockback, player.whoAmI);
				player.AddBuff(2, 60);
				player.AddBuff(115, 120);
				player.AddBuff(48, 60);

				

			}
			

			player.AddBuff(2, 60);
			player.AddBuff(115, 120);
			player.AddBuff(48, 30);

			return true;
		}
	}
}