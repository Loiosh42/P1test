using Microsoft.Xna.Framework;
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

namespace P1test
{
	public class P1testPlayer : ModPlayer
	{
		//public bool QuantProj = false;
		public bool Cursed = false;
		public bool Slagged = false;
		public bool QuProHit = false;
		public bool CelGauntBuf = false;
		public bool SolBurn = false;
		public bool VoiBurn = false;
		public bool MiniPort = false;
		public bool MiniPort2 = false;
		public float PlaySpeedX = 0;
		public float PlaySpeedY = 0;
		public bool Scarf = false;
		public bool Scarfe = false;
		public bool GLOOed = false;
		public bool SevLBoots = false;
		public float PlayerX2 = 0f;
		public float PlayerY2 = 0f;
		public float PlayerVX2 = 0f;
		public float PlayerVY2 = 0f;
		public float PlayerPos = 0f;
		public bool Wasped = false;
        // for the shield, code is in PreHurt() and PostUpdate()
        public bool ShieldActive = false; //Activated when accesory equipped.
        public double ShieldMaxHP = 0; //Shield health max, use for max in UI
        public double ShieldHP = 0; //Shield "health" counter, use for current in UI
		public double ShieldRegen = 0;
		public int ShieldCooldownMax = 0; //Total cooldown, cooldown until shield starts to regen
        public int ShieldCooldown = 0; //Cooldown counter, 0 is shield active
		public float ShieldResist = 0f; //effectiveness of shield, 0f is all damage through, 0.5f is half damage through, 1f is all damage goes to shield hp
		//sum of damage to health and damage to shield is incoming damage
		//to change damage to health, use damage reduction when shield active
		// might need another var for shield active damage reduction

        public override void ResetEffects()
		{
			//QuantProj = false;
			Slagged = false;
			QuProHit = false;
			CelGauntBuf = false;
			SolBurn = false;
			VoiBurn = false;
			MiniPort = false;
			MiniPort2 = false;
			Cursed = false;
			PlaySpeedX = 0;
			PlaySpeedY = 0;
			Scarfe = false;
			Scarf = false;
			GLOOed = false;
			SevLBoots = false;
			PlayerX2 = 0f;
			PlayerY2 = 0f;
			PlayerVX2 = 0f;
			PlayerVY2 = 0f;
			PlayerPos = 0f;
			Wasped = false;

            ShieldActive = false;
            ShieldMaxHP = 0;
			ShieldCooldownMax = 0;
            ShieldResist = 0f;
            ShieldRegen = 0;
        }


        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
        {
            //int DONTCHANGTHISDAM = damage; //irrelevant backup?
            if (ShieldActive == true) //more notes with variable initialization
            {
                int damageToShield = damage;
                if (ShieldHP > 0)//&& ShieldCooldown <= 0)
                {
                    damageToShield = (int)(damage * ShieldResist);
                    ShieldHP -= damageToShield;
                    damage -= damageToShield;
                    ShieldCooldown = ShieldCooldownMax;
                    if (ShieldHP <= 0) { ShieldHP = 0; }
                }
                else
                {
                    ShieldCooldown = ShieldCooldownMax;
                }
				for (int i = 0; i <= 6; i++)
				{
					//Vector2 Playerpos2 = new Vector2(PlayerPos.X, PlayerPos.Y);
					Dust.NewDust(Player.position, 40, 40, 135, 0f, 0f, 100, default(Color), 2f);
				}
				return true;
            }
            //if (SHLDon == true & ShCooldown < 2 & SHLDon2 == true)
            //{

            //	if (ShHP >= 3)
            //	{
            //		damage = TshDam / 4;
            //		ShHP = ShHP - (TshDam / 2);
            //	}

            //}
            //if (ShHP < 3)
            //{
            //	ShCooldown = 600;
            //	SHLDon2 = false;
            //	damage = TshDam;
            //}
            return true;
        }



        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit, int cooldownCounter)
		{
			if (MiniPort == true)
			{
		
				Player.AddBuff(Mod.Find<ModBuff>("MiniPortBuff").Type, 300);
				
				
			}
			if (MiniPort2 == true)
			{
				Player.AddBuff(61, 300);
				Player.AddBuff(Mod.Find<ModBuff>("MiniPortBuff1").Type, 1);
				Player.AddBuff(73, 300);

			}
		}

		public override void PreUpdateMovement()
		{
			if (GLOOed == true)
			{
				Vector2 newVelocity = Player.velocity;
				newVelocity = newVelocity * 0.1f;
				Player.velocity = newVelocity;
			}	
		}

		public override void OnHitNPC(Item item, NPC target, int damage, float knockBack, bool crit)
		{


		if (CelGauntBuf == true)
			{//player.AddBuff(14, 3000000);
			 //player.AddBuff(71, 3000000);
			 //player.AddBuff(73, 3000000);
			 //player.AddBuff(74, 3000000);
			 //player.AddBuff(75, 3000000);
			 //player.AddBuff(76, 3000000);
			 //player.AddBuff(77, 3000000);
			 //player.AddBuff(79, 3000000);
			 //player.AddBuff(322, 3000000);
				if (Main.dayTime)
				{
					target.AddBuff(Mod.Find<ModBuff>("SolarConflagration").Type, 400);
					//target.AddBuff(BuffID.OnFire, 300, true);

					//target.AddBuff(BuffID.ShadowFlame, 300, false);
					//target.AddBuff(BuffID.Bleeding, 300, false);
					//target.AddBuff(BuffID.CursedInferno, 300, false);
					//target.AddBuff(BuffID.ShadowFlame, 300, false);
					target.AddBuff(BuffID.Ichor, 600);
					//target.AddBuff(BuffID.Poisoned, 300, false);
					//target.AddBuff(BuffID.Burning, 300, false);
					//target.AddBuff(20, 300);
					//target.AddBuff(24, 300);
					//target.AddBuff(30, 300);
					//target.AddBuff(39, 300);
					//target.AddBuff(69, 300);
					//target.AddBuff(70, 300);
					//target.AddBuff(153, 300);
					//target.AddBuff(323, 300);
				}
				else
				{
					target.AddBuff(Mod.Find<ModBuff>("VoidBurn").Type, 400);
					target.AddBuff(BuffID.Suffocation, 300, false);
					//target.AddBuff(BuffID.Bleeding, 300, false);
					//target.AddBuff(BuffID.Poisoned, 300, false);
					target.AddBuff(31, 600);
					target.AddBuff(32, 600);
					target.AddBuff(160, 600);
					target.AddBuff(BuffID.Frostburn, 300, false);
					//target.AddBuff(20, 300);
					//target.AddBuff(30, 300);
					//target.AddBuff(44, 300);
					//target.AddBuff(47, 300);
					//target.AddBuff(68, 300);
					//target.AddBuff(70, 300);
					//target.AddBuff(144, 300);
					//target.AddBuff(324, 300);
				}
			}
			
		}

		public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{

			if (QuProHit == true)
            {
				//if (type == ProjectileID.Bullet) // or ProjectileID.WoodenArrowFriendly
				//{
					//type = mod.ProjectileType("CGPro");
					type = 207;
					//type = mod.ProjectileType("Qutp"); // or ProjectileID.FireArrow;
					return true;//false
				//}
				//else { return true; }
			}
            else { return true; }
		}

		public override void UpdateBadLifeRegen()
        {
			if(SolBurn == true)
            {
				if (Player.lifeRegen > 0)
				{
					Player.lifeRegen = 0;
				}
				Player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 40 life lost per second.
				Player.lifeRegen -= 80;
			}

			if(VoiBurn == true)
            {
				if (Player.lifeRegen > 0)
				{
					Player.lifeRegen = 0;
				}
				Player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 30 life lost per second.
				Player.lifeRegen -= 60;
			}

			if (Wasped == true)
			{
				if (Player.lifeRegen > 0)
				{
					Player.lifeRegen = 0;
				}
				Player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 150 life lost per second.
				Player.lifeRegen -= 300;
			}

			if (Slagged == true)
			{
				if (Player.lifeRegen > 0)
				{
					Player.lifeRegen = 0;
				}
				Player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 15 life lost per second.
				Player.lifeRegen -= 30;
			}
			if (Cursed == true)
			{
				if (Player.lifeRegen > 0)
				{
					Player.lifeRegen = 0;
				}
				Player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 5 life lost per second.
				Player.lifeRegen -= 10;
			}

		}
		//public override void OnShoot()

		public override void PostUpdate()
        {
			Scarfe = false;
			PlaySpeedX = Player.velocity.X;
			PlaySpeedY = Player.velocity.Y;

			if (ShieldCooldown > 0)
			{
				ShieldCooldown--;
			}
			if (ShieldCooldown <= 0 && ShieldHP < ShieldMaxHP)
			{
				ShieldHP += ShieldRegen;
			}

				//if (ShCooldown >= 1)
				//{
				//	ShCooldown = ShCooldown - 1;
				//	ShHP = 300; //needs changing so UI is not bugged
				//	SHLDon2 = false;
				//}
			
				//else
				//{
				//	if (ShHP < 300)
				//	{
				//		ShHP = ShHP + 1;
				//	}

				//	SHLDon2 = true;
				//}

		}
	}
}