using System;
using System.Collections.Generic;

namespace temfullcn.Models;

public partial class Huanluyenvien
{
    public string HuanLuyenVienId { get; set; } = null!;

    public string? TenHlv { get; set; }

    public int? NamSinh { get; set; }

    public string? QuocTich { get; set; }

    public string? Anh { get; set; }

    public virtual ICollection<Caulacbo> Caulacbos { get; set; } = new List<Caulacbo>();
}
