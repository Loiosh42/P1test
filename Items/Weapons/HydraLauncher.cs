using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace P1test.Items.Weapons
{
	public class HydraLauncher : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Like Bloons"); // to edit
			
			//Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
			//ItemID.Sets.AnimatesAsSoul[item.type] = true;
			//ItemID.Sets.ItemIconPulse[item.type] = true;
			//ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		
		public override void SetDefaults() {
			Item.damage = 2;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 80; 
			Item.height = 36; 
			Item.useTime = 6;
			Item.useAnimation = Item.useTime;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = 100000000;
			Item.rare = ItemRarityID.Red;
			//item.UseSound = SoundID.2:61;
			Item.shoot = Mod.Find<ModProjectile>("HydraRocket").Type;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Rocket;
			Item.autoReuse = true;
			//item.useAnimation = 12;
			//item.useTime = 4;
			//item.reuseDelay = 14;
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .75f;
			// Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (useAnimation - 1, then - useTime until less than 0.) 
			// We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
			//return !(player.itemAnimation < item.useAnimation - 2);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, -1);
		}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			type = Mod.Find<ModProjectile>("HydraRocket").Type;
			//type = ProjectileID.RocketSnowmanI;
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(6));
			velocity.X = perturbedSpeed.X;
			velocity.Y = perturbedSpeed.Y;

			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 65f;//25
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}


			/*int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X, projectile.velocity.Y, 100f, default(Color), 1f);

			Main.dust[num1].noGravity = true;
			Main.dust[num1].velocity *= 0.1f;*/

			/*float numberProjectiles = 7;
			float rotation = MathHelper.ToRadians(5);//45
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 5f;//45
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .3f; // Watch out for dividing by 0 if there is only 1 projectile.//0.2f
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}*/
			return true;
		}
		
	}
}	