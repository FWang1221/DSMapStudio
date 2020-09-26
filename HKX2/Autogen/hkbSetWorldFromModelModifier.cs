using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkbSetWorldFromModelModifier : hkbModifier
    {
        public Vector4 m_translation;
        public Quaternion m_rotation;
        public bool m_setTranslation;
        public bool m_setRotation;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            br.ReadUInt64();
            m_translation = des.ReadVector4(br);
            m_rotation = des.ReadQuaternion(br);
            m_setTranslation = br.ReadBoolean();
            m_setRotation = br.ReadBoolean();
            br.ReadUInt64();
            br.ReadUInt32();
            br.ReadUInt16();
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteUInt64(0);
            bw.WriteBoolean(m_setTranslation);
            bw.WriteBoolean(m_setRotation);
            bw.WriteUInt64(0);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
        }
    }
}
