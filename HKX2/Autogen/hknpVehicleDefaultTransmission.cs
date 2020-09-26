using SoulsFormats;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    public class hknpVehicleDefaultTransmission : hknpVehicleTransmission
    {
        public float m_downshiftRPM;
        public float m_upshiftRPM;
        public float m_primaryTransmissionRatio;
        public float m_clutchDelayTime;
        public float m_reverseGearRatio;
        public List<float> m_gearsRatio;
        public List<float> m_wheelsTorqueRatio;
        
        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_downshiftRPM = br.ReadSingle();
            m_upshiftRPM = br.ReadSingle();
            m_primaryTransmissionRatio = br.ReadSingle();
            m_clutchDelayTime = br.ReadSingle();
            m_reverseGearRatio = br.ReadSingle();
            br.ReadUInt32();
            m_gearsRatio = des.ReadSingleArray(br);
            m_wheelsTorqueRatio = des.ReadSingleArray(br);
        }
        
        public override void Write(BinaryWriterEx bw)
        {
            base.Write(bw);
            bw.WriteSingle(m_downshiftRPM);
            bw.WriteSingle(m_upshiftRPM);
            bw.WriteSingle(m_primaryTransmissionRatio);
            bw.WriteSingle(m_clutchDelayTime);
            bw.WriteSingle(m_reverseGearRatio);
            bw.WriteUInt32(0);
        }
    }
}
