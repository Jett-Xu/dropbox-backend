namespace dropbox_backend.Models;

public class StorageInfo
{
    public int Id { get; set; }
    public int Used { get; set; }
    public int Total { get; set; }
    public string Unit { get; set; } = string.Empty;
    public int Percentage { get; set; }
}
