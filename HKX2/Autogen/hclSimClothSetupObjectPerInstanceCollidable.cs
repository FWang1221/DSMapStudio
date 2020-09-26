using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hclSimClothSetupObjectPerInstanceCollidable : IHavokObject
    {
        public hclCollidable m_collidable;
        public hclVertexSelectionInput m_collidingParticles;
        public string m_drivingBoneName;
        public bool m_pinchDetectionEnabled;
        public sbyte m_pinchDetectionPriority;
        public float m_pinchDetectionRadius;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_collidable = des.ReadClassPointer<hclCollidable>(br);
            m_collidingParticles = new hclVertexSelectionInput();
            m_collidingParticles.Read(des, br);
            m_drivingBoneName = des.ReadStringPointer(br);
            m_pinchDetectionEnabled = br.ReadBoolean();
            m_pinchDetectionPriority = br.ReadSByte();
            br.ReadUInt16();
            m_pinchDetectionRadius = br.ReadSingle();
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            // Implement Write
            m_collidingParticles.Write(bw);
            bw.WriteBoolean(m_pinchDetectionEnabled);
            bw.WriteSByte(m_pinchDetectionPriority);
            bw.WriteUInt16(0);
            bw.WriteSingle(m_pinchDetectionRadius);
        }
    }
}
