using System;
using Server.Engines.Craft;
using Server.Network;
using System.Collections.Generic;

namespace Server.Items
{
	public abstract class BaseHat : BaseClothing, IShipwreckedItem
	{
		private bool m_IsShipwreckedItem;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsShipwreckedItem
		{
			get { return m_IsShipwreckedItem; }
			set { m_IsShipwreckedItem = value; }
		}

		public BaseHat( int itemID ) : this( itemID, 0 )
		{
		}

		public BaseHat( int itemID, int hue ) : base( itemID, Layer.Helm, hue )
		{
		}

		public BaseHat( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( m_IsShipwreckedItem );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_IsShipwreckedItem = reader.ReadBool();
					break;
				}
			}
		}

		public override void AddEquipInfoAttributes( Mobile from, List<EquipInfoAttribute> attrs )
		{
			base.AddEquipInfoAttributes( from, attrs );

			if( m_IsShipwreckedItem )
				attrs.Add( new EquipInfoAttribute( 1041645 ) );	// recovered from a shipwreck
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

			if ( m_IsShipwreckedItem )
				list.Add( 1041645 ); // recovered from a shipwreck
		}

		public override int OnCraft( int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			Quality = (ClothingQuality)quality;

			if( Quality == ClothingQuality.Exceptional )
				DistributeBonuses( (tool is BaseRunicTool ? 6 : (Core.SE ? 15 : 14)) );	//BLAME OSI. (We can't confirm it's an OSI bug yet.)

			return base.OnCraft( quality, makersMark, from, craftSystem, typeRes, tool, craftItem, resHue );
		}

	}
}