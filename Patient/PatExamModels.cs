namespace DiagnPortal.API.Patient;

public class ExaminationDisplayModel
{
    public long PATCODE { get; set; }
    public string? PATLAST { get; set; }
    public string? PATFIRST { get; set; }
    public List<PacketGroup> PacketGroups { get; set; } = new List<PacketGroup>();
    public List<ExaminationDetail> LaboratoryExaminations { get; set; } = new List<ExaminationDetail>();
    public List<ExaminationDetail> NonLaboratoryExaminations { get; set; } = new List<ExaminationDetail>();
    public bool HasFiles { get; set; }
}

public class PacketGroup
{
    public string? EXHEADER { get; set; }
    public string? EXHEADERNAME { get; set; }
    public List<ExaminationDetail> Examinations { get; set; } = new List<ExaminationDetail>();
}

public class ExaminationDetail
{
    public string? EXCODE { get; set; }
    public string? EXNAME { get; set; }
    public string? APOTEL { get; set; }
    public string? UNITS { get; set; }
    public string? NORMALVALUES { get; set; }
    public bool? ABNORMALSTATUS { get; set; }
    public bool HASFILES { get; set; }
    public List<FileData> FILES { get; set; } = new List<FileData>();
}

public class FileData
{
    public string? FILENAME { get; set; }
    public string? FILEEXT { get; set; }
    public byte[]? FILEDATA { get; set; }
}