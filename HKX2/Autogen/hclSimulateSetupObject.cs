using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hclSimulateSetupObject : hclOperatorSetupObject
    {
        public string m_name;
        public hclSimClothSetupObject m_simClothSetupObject;
        public uint m_numberOfSubsteps;
        public uint m_numberOfSolveIterations;
        public bool m_adaptConstraintStiffness;
        public bool m_explicitConstraintOrder;
        public List<hclConstraintSetSetupObject> m_constraintSetExecutionOrder;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_name = des.ReadStringPointer(br);
            m_simClothSetupObject = des.ReadClassPointer<hclSimClothSetupObject>(br);
            m_numberOfSubsteps = br.ReadUInt32();
            m_numberOfSolveIterations = br.ReadUInt32();
            m_adaptConstraintStiffness = br.ReadBoolean();
            m_explicitConstraintOrder = br.ReadBoolean();
            br.ReadUInt32();
            br.ReadUInt16();
            m_constraintSetExecutionOrder = des.ReadClassPointerArray<hclConstraintSetSetupObject>(br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            // Implement Write
            bw.WriteUInt32(m_numberOfSubsteps);
            bw.WriteUInt32(m_numberOfSolveIterations);
            bw.WriteBoolean(m_adaptConstraintStiffness);
            bw.WriteBoolean(m_explicitConstraintOrder);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
        }
    }
}
