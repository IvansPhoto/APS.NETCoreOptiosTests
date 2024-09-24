using System.ComponentModel.DataAnnotations;

namespace MonitorSnapshot;

public sealed class Cfg
{
    public const string Section = "Section";
    
    [Required] 
    public string FirstStr { get; init; } = string.Empty;
    [Required] 
    public string SecondStr { get; init; } = string.Empty;
    [Required]
    [Range(0, 100)]
    public int Number { get; init; } = 1;
}