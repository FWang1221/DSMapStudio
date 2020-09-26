using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hkbManualSelectorGeneratorInternalState : hkReferencedObject
    {
        public short m_currentGeneratorIndex;
        public short m_generatorIndexAtActivate;
        public List<hkbStateMachineActiveTransitionInfo> m_activeTransitions;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_currentGeneratorIndex = br.ReadInt16();
            m_generatorIndexAtActivate = br.ReadInt16();
            br.ReadUInt32();
            m_activeTransitions = des.ReadClassArray<hkbStateMachineActiveTransitionInfo>(br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteInt16(m_currentGeneratorIndex);
            bw.WriteInt16(m_generatorIndexAtActivate);
            bw.WriteUInt32(0);
        }
    }
}
