using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkVertexFormatElement : IHavokObject
    {
        public ComponentType m_dataType;
        public byte m_numValues;
        public ComponentUsage m_usage;
        public byte m_subUsage;
        public byte m_flags;
        public byte m_pad_0;
        public byte m_pad_1;
        public byte m_pad_2;
        
        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_dataType = (ComponentType)br.ReadByte();
            m_numValues = br.ReadByte();
            m_usage = (ComponentUsage)br.ReadByte();
            m_subUsage = br.ReadByte();
            m_flags = br.ReadByte();
            m_pad_0 = br.ReadByte();
            m_pad_1 = br.ReadByte();
            m_pad_2 = br.ReadByte();
        }
        
        public virtual void Write(BinaryWriterEx bw)
        {
            bw.WriteByte(m_numValues);
            bw.WriteByte(m_subUsage);
            bw.WriteByte(m_pad_0);
            bw.WriteByte(m_pad_1);
            bw.WriteByte(m_pad_2);
        }
    }
}
