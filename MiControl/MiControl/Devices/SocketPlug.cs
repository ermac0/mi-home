using System.Globalization;
using MiControl.Commands;
using Newtonsoft.Json.Linq;

namespace MiControl.Devices
{
    public class SocketPlug : MiHomeDevice
    {
        private readonly UdpTransport _transport;
        public SocketPlug(string sid, UdpTransport transport) : base(sid, "plug")
        {
            _transport = transport;
        }

        public string Status { get; private set; }
        public int? Inuse { get; private set; }
        public int? PowerConsumed { get; private set; }
        public float? LoadPower { get; private set; }


        public override string ToString()
        {
            return $"Status: {Status}, Inuse: {Inuse}, Load Power: {LoadPower}V, Power Consumed: {PowerConsumed}W, Voltage: {Voltage}V";
        }

        public void TurnOff()
        {
            _transport.SendWriteCommand(Sid, Type, new SocketPlugCommand("off"));
        }

        public void TurnOn()
        {
            _transport.SendWriteCommand(Sid, Type, new SocketPlugCommand());
        }

        public override void ParseData(JObject data)
        {

            if (data["inuse"] != null && int.TryParse(data["inuse"].ToString(), out int inuse))
            {
                Inuse = inuse;
            }

            if (data["power_consumed"] != null && int.TryParse(data["power_consumed"].ToString(), out int powerConsumed))
            {
                PowerConsumed = powerConsumed;
            }

            if (data["load_power"] != null && float.TryParse(data["load_power"].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out float loadPower))
            {
                LoadPower = loadPower;
            }

            if (data["status"] != null)
            {
                Status = data["status"].ToString();
            }
        }
    }
}