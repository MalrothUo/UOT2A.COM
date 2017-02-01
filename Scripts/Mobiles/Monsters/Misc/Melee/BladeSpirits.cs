using System;
using System.Collections;

namespace Server.Mobiles
{
    [CorpseName( "a blade spirit corpse" )]
	public class BladeSpirits : BaseCreature
	{
		public override bool DeleteCorpseOnDeath { get { return false; } }
		public override bool IsHouseSummonable { get { return true; } }

		public override double DispelDifficulty { get { return 0.0; } }
		public override double DispelFocus { get { return 20.0; } }

		public override double GetFightModeRanking( Mobile m, FightMode acqType, bool bPlayerOnly )
		{
			return ( m.Str + m.Skills[SkillName.Tactics].Value ) / Math.Max( GetDistanceToSqrt( m ), 1.0 );
		}

		[Constructable]
		public BladeSpirits()
			: base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.3, 0.6 )
		{
			Name = "a blade spirit";
			Body = 574;

			SetStr( 150 );
			SetDex( 150 );
			SetInt( 100 );

			SetHits( 80 );
			SetStam( 250 );
			SetMana( 0 );

			SetDamage( 10, 14 );

			SetSkill( SkillName.MagicResist, 70.0 );
			SetSkill( SkillName.Tactics, 90.0 );
			SetSkill( SkillName.Wrestling, 90.0 );

			Fame = 0;
			Karma = 0;

			VirtualArmor = 40;
			ControlSlots = 1;
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune { get { return Poison.Lethal; } }

		public override int GetAngerSound()
		{
			return 0x23A;
		}

		public override int GetAttackSound()
		{
			return 0x3B8;
		}

		public override int GetHurtSound()
		{
			return 0x23A;
		}

		public BladeSpirits( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}