using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hclStandardLinkSetupObject : hclConstraintSetSetupObject
    {
        public string m_name;
        public hclSimulationSetupMesh m_simulationMesh;
        public hclVertexSelectionInput m_vertexSelection;
        public hclEdgeSelectionInput m_edgeSelection;
        public bool m_ignoreHiddenEdges;
        public hclVertexFloatInput m_stiffness;
        public hclVertexFloatInput m_allowedCompression;
        public hclVertexFloatInput m_allowedStretching;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_name = des.ReadStringPointer(br);
            m_simulationMesh = des.ReadClassPointer<hclSimulationSetupMesh>(br);
            m_vertexSelection = new hclVertexSelectionInput();
            m_vertexSelection.Read(des, br);
            m_edgeSelection = new hclEdgeSelectionInput();
            m_edgeSelection.Read(des, br);
            m_ignoreHiddenEdges = br.ReadBoolean();
            br.ReadUInt32();
            br.ReadUInt16();
            br.ReadByte();
            m_stiffness = new hclVertexFloatInput();
            m_stiffness.Read(des, br);
            m_allowedCompression = new hclVertexFloatInput();
            m_allowedCompression.Read(des, br);
            m_allowedStretching = new hclVertexFloatInput();
            m_allowedStretching.Read(des, br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            // Implement Write
            m_vertexSelection.Write(bw);
            m_edgeSelection.Write(bw);
            bw.WriteBoolean(m_ignoreHiddenEdges);
            bw.WriteUInt32(0);
            bw.WriteUInt16(0);
            bw.WriteByte(0);
            m_stiffness.Write(bw);
            m_allowedCompression.Write(bw);
            m_allowedStretching.Write(bw);
        }
    }
}
