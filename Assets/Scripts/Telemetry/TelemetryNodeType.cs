
public class TelemetryNodeType
{
    public string Value { get; set; }

    private TelemetryNodeType(string value) { Value = value; }

    public static TelemetryNodeType Entity { get { return new TelemetryNodeType("Entity"); } }
    public static TelemetryNodeType Activity { get { return new TelemetryNodeType("Activity"); } }
    public static TelemetryNodeType Agent { get { return new TelemetryNodeType("Agent"); } }
}
