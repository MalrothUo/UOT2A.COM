namespace Server.Items
{
    public class GiftBoxAngel : BaseContainer
    {
        public override int DefaultGumpID { get { return 0x11F; } }

        [Constructable]
        public GiftBoxAngel()
            : base(0x46A7)
        {
            Hue = GiftBoxHues.RandomGiftBoxHue;
        }

        public GiftBoxAngel(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}