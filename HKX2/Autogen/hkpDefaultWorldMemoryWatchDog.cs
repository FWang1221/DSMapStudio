using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkpDefaultWorldMemoryWatchDog : hkWorldMemoryAvailableWatchDog
    {
        public int m_freeHeapMemoryRequested;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_freeHeapMemoryRequested = br.ReadInt32();
            br.ReadUInt32();
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteInt32(m_freeHeapMemoryRequested);
            bw.WriteUInt32(0);
        }
    }
}
