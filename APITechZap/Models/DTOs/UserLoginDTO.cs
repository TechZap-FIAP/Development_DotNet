using System.ComponentModel.DataAnnotations.Schema;

namespace APITechZap.Models.DTOs;

public class UserLoginDTO
{
    public string DsEmail { get; set; }
    public string DsPassword { get; set; }
}
